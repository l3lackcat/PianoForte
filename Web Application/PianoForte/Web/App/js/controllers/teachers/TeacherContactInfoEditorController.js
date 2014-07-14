'use strict';

goog.provide('PianoForte.Controllers.Teachers.TeacherContactInfoEditorController');

PianoForte.Controllers.Teachers.TeacherContactInfoEditorController = function ($scope, $rootScope, TeacherService, Enum, EnumConverter, FormatManager, ValidationManager) {
    $scope['Enum'] = Enum;

    $scope['originalData'] = null;
    $scope['edittedData'] = null;
    $scope['visible'] = false;
    $scope['isOnUpdateEdittedData'] = false;
    $scope['numberOfActivePhones'] = 0;
    $scope['numberOfActiveEmails'] = 0;

    var requestInsertContactList = [];
    var requestUpdateContactList = [];
    var requestDeleteContactList = [];

    $scope.$on('EditTeacherContactInfo', function (scope, teacherId, contacts) {
        $scope['originalData'] = {
            'teacherId': teacherId,
            'phones': contacts.phones,
            'emails': contacts.emails
        };
        $scope['edittedData'] = {
            'phones': [],
            'emails': []
        };

        var phoneLength = $scope['originalData']['phones'].length;
        for(var i = 0; i < phoneLength; i++) {
            var phone = $scope['originalData']['phones'][i];

            $scope['edittedData']['phones'].push({
                'id': phone.id,
                'label': phone.label,
                'value': phone.value,
                'status': phone.status,
                'isPrimary': phone.isPrimary || false,
                'isValid': true
            });
        }

        if ($scope['edittedData']['phones'].length === 0) {
            $scope.addPhone();
        }            

        var emailLength = $scope['originalData']['emails'].length;
        for(var i = 0; i < emailLength; i++) {
            var email = $scope['originalData']['emails'][i];

            $scope['edittedData']['emails'].push({
                'id': email.id,
                'label': email.label,
                'value': email.value,
                'status': email.status,
                'isPrimary': email.isPrimary || false,
                'isValid': true
            });
        }

        if ($scope['edittedData']['emails'].length === 0) {
            $scope.addEmail();
        } 

        $scope['visible'] = true;        
    } .bind(this), true);

    $scope.submit = function () {
        if (validateEdittedData() === true) { 
            $scope['isOnUpdateEdittedData'] = true;        

            submitEmails();
            submitPhones();

            if ((requestInsertContactList.length === 0) &&
                (requestUpdateContactList.length === 0) &&
                (requestDeleteContactList.length === 0)) {                

                hideDialogBox();
            }
        }
    };

    $scope.cancel = function () {
        hideDialogBox();
    };    

    $scope.addPhone = function () {
        var id = -1;

        for(var i = $scope['edittedData']['phones'].length - 1; i >= 0; i--) {
            var phone = $scope['edittedData']['phones'][i];
            if (phone.id < 0) {
                id--;
            }
        }

        $scope['edittedData']['phones'].push({
            'id': id,
            'label': '',
            'value': '',
            'status': Enum.Status.Active,
            'isPrimary': false,
            'isValid': true
        });
    };

    $scope.removePhone = function (removedPhone) {
        if (removedPhone.id < 0) {
            for(var i = $scope['edittedData']['phones'].length - 1; i >= 0; i--) {
                var phone = $scope['edittedData']['phones'][i];
                if (phone.id === removedPhone.id) {
                    $scope['edittedData']['phones'].splice(i, 1);
                    break;
                }
            }                    
        } else {
            removedPhone.status = Enum.Status.Deleted;
            removedPhone.isPrimary = false;        
        } 

        var hasActivePhone = false
        for(var i = $scope['edittedData']['phones'].length - 1; i >= 0; i--) {
            var phone = $scope['edittedData']['phones'][i];
            if (phone.status === Enum.Status.Active) {
                hasActivePhone = true;
                break;
            }
        }

        if (hasActivePhone === false) {
            $scope.addPhone();
        }                  
    };

    $scope.onCheckedPrimaryPhone = function(e) {
        if (e.checked === true) {
            for(var i = $scope['edittedData']['phones'].length - 1; i >= 0; i--) {
                var phone = $scope['edittedData']['phones'][i];
                if (phone.id !== e.name) {
                    phone.isPrimary = false;
                }
            }
        }
    };

    $scope.addEmail = function () {
        var id = -1;

        for(var i = $scope['edittedData']['emails'].length - 1; i >= 0; i--) {
            var email = $scope['edittedData']['emails'][i];
            if (email.id < 0) {
                id--;
            }
        }

        $scope['edittedData']['emails'].push({
            'id': id,
            'label': '',
            'value': '',
            'status': Enum.Status.Active,
            'isPrimary': false,
            'isValid': true
        });
    };

    $scope.removeEmail = function (removedEmail) {
        if (removedEmail.id < 0) {
            for(var i = $scope['edittedData']['emails'].length - 1; i >= 0; i--) {
                var email = $scope['edittedData']['emails'][i];
                if (email.id === removedEmail.id) {
                    $scope['edittedData']['emails'].splice(i, 1);
                    break;
                }
            }                    
        } else {
            removedEmail.status = Enum.Status.Deleted;
            removedEmail.isPrimary = false;        
        } 

        var hasActiveEmail = false
        for(var i = $scope['edittedData']['emails'].length - 1; i >= 0; i--) {
            var email = $scope['edittedData']['emails'][i];
            if (email.status === Enum.Status.Active) {
                hasActiveEmail = true;
                break;
            }
        }

        if (hasActiveEmail === false) {
            $scope.addEmail();
        }
    };

    $scope.onCheckedPrimaryEmail = function(e) {
        if (e.checked === true) {
            for(var i = $scope['edittedData']['emails'].length - 1; i >= 0; i--) {
                var email = $scope['edittedData']['emails'][i];
                if (email.id !== e.name) {
                    email.isPrimary = false;
                }
            }
        }
    };

    function hideDialogBox() {
        $scope['originalData'] = null;
        $scope['edittedData'] = null;
        $scope['visible'] = false;
        $scope['isOnUpdateEdittedData'] = false;

        $scope['numberOfActivePhones'] = 0;
        $scope['numberOfActiveEmails'] = 0;
    };    

    function submitEmails () {
        for(var i = $scope['edittedData']['emails'].length - 1; i >= 0; i--) {
            var newEmail = $scope['edittedData']['emails'][i];
            newEmail.type = Enum.ContactType.Email;
            newEmail.teacherId = $scope['originalData']['teacherId'];
            if (newEmail.label === '') {
                newEmail.label = 'อีเมล์'
            }

            if (newEmail.id < 0) {
                if (newEmail.status !== Enum.Status.Deleted) {
                    if (newEmail.value !== '') {
                        // Insert new phone   
                        requestInsertContactList.push(newEmail);                      
                        TeacherService.insertTeacherContactInfo(newEmail, onSuccessInsertTeacherContactInfo, onErrorInsertTeacherContactInfo);
                    }
                }                        
            } else {
                if (newEmail.status === Enum.Status.Deleted) {
                    // Delete new phone
                    requestDeleteContactList.push(newEmail);
                    TeacherService.deleteTeacherContactInfo(newEmail, onSuccessDeleteTeacherContactInfo, onErrorDeleteTeacherContactInfo);
                } else {
                    for(var j = $scope['originalData']['emails'].length - 1; j >= 0; j--) {
                        var oldEmail = $scope['originalData']['emails'][j];

                        if ((oldEmail.id === newEmail.id)) {
                            if ((oldEmail.label !== newEmail.label) || (oldEmail.value !== newEmail.value) || (oldEmail.isPrimary !== newEmail.isPrimary)) {
                                // Update phone
                                requestUpdateContactList.push(newEmail);
                                TeacherService.updateTeacherContactInfo(newEmail, onSuccessUpdateTeacherContactInfo, onErrorUpdateTeacherContactInfo);
                            }

                            break;
                        }
                    }
                }                        
            }                    
        }
    };

    function submitPhones () {
        for(var i = $scope['edittedData']['phones'].length - 1; i >= 0; i--) {
            var newPhone = $scope['edittedData']['phones'][i];                
            newPhone.type = Enum.ContactType.Phone;                
            newPhone.teacherId = $scope['originalData']['teacherId'];
            newPhone.value = FormatManager.unformatPhoneNumber(newPhone.value);
            if (newPhone.label === '') {
                newPhone.label = 'เบอร์โทร'
            }

            if (newPhone.id < 0) {
                if (newPhone.status !== Enum.Status.Deleted) {
                    if (newPhone.value !== '') {
                        // Insert new phone                    
                        requestInsertContactList.push(newPhone);                    
                        TeacherService.insertTeacherContactInfo(newPhone, onSuccessInsertTeacherContactInfo, onErrorInsertTeacherContactInfo);
                    }
                }                        
            } else {
                if (newPhone.status === Enum.Status.Deleted) {
                    // Delete new phone
                    requestDeleteContactList.push(newPhone);
                    TeacherService.deleteTeacherContactInfo(newPhone, onSuccessDeleteTeacherContactInfo, onErrorDeleteTeacherContactInfo);
                } else {
                    for(var j = $scope['originalData']['phones'].length - 1; j >= 0; j--) {
                        var oldPhone = $scope['originalData']['phones'][j];                        

                        if ((oldPhone.id === newPhone.id)) {
                            if ((oldPhone.label !== newPhone.label) || (oldPhone.value !== newPhone.value) || (oldPhone.isPrimary !== newPhone.isPrimary)) {
                                // Update phone
                                requestUpdateContactList.push(newPhone);
                                TeacherService.updateTeacherContactInfo(newPhone, onSuccessUpdateTeacherContactInfo, onErrorUpdateTeacherContactInfo);
                            }

                            break;
                        }
                    }
                }                        
            }                    
        }
    };

    function validateEdittedData () {
        var isValid = true;

        var numberOfActivePhones = $scope['edittedData']['phones'].length;
        for(var i = $scope['edittedData']['phones'].length - 1; i >= 0; i--) {
            var phone = $scope['edittedData']['phones'][i];
            phone.isValid = true;

            if (phone.id > 0) {
                if (phone.status === Enum.Status.Active) {
                    if (ValidationManager.validate('phone', phone.value) === false) {
                        phone.isValid = false;
                        isValid = false;
                    }
                } else {
                    numberOfActivePhones--;
                }                                
            } else {
                if (phone.value !== '') {
                    if (ValidationManager.validate('phone', phone.value) === false) {
                        phone.isValid = false;
                        isValid = false;
                    }
                } else {
                    $scope['edittedData']['phones'].splice(i, 1);
                    numberOfActivePhones--;
                }               
            }
        }

        var numberOfActiveEmails = $scope['edittedData']['emails'].length;
        for(var i = $scope['edittedData']['emails'].length - 1; i >= 0; i--) {
            var email = $scope['edittedData']['emails'][i];
            email.isValid = true;

            if (email.id > 0) {
                if (email.status === Enum.Status.Active) {
                    if (ValidationManager.validate('email', email.value) === false) {
                        email.isValid = false;
                        isValid = false;
                    } 
                } else {
                    numberOfActiveEmails--;
                }
            } else {
                if (email.value !== '') {
                    if (ValidationManager.validate('email', email.value) === false) {
                        email.isValid = false;
                        isValid = false;
                    }
                } else {
                    $scope['edittedData']['emails'].splice(i, 1);
                    numberOfActiveEmails--;
                }
            }
        }

        $scope['numberOfActivePhones'] = numberOfActivePhones;
        $scope['numberOfActiveEmails'] = numberOfActiveEmails;

        return isValid;
    };

    var onSuccessInsertTeacherContactInfo = function (data, status, headers, config) {
        var insertedContactId = data.d;
        if (insertedContactId > 0) {
            var insertedContact = config.data.teacherContact;
            if (insertedContact !== null) {
                if (insertedContact.Type === Enum.ContactType.Phone) {
                    $scope['originalData']['phones'].push({
                        'id': insertedContactId,
                        'label': insertedContact.Label,
                        'value': insertedContact.Content,
                        'status': insertedContact.Status,
                        'isPrimary': insertedContact.IsPrimary
                    });

                    for(var i = requestInsertContactList.length - 1; i >= 0; i--) {
                        var contact = requestInsertContactList[i];

                        if ((contact.label === insertedContact.Label) && (contact.value === insertedContact.Content) && (contact.status === insertedContact.Status)) {
                            requestInsertContactList.splice(i, 1);
                            break;
                        }
                    }
                } else if (insertedContact.Type === Enum.ContactType.Email) {
                    $scope['originalData']['emails'].push({
                        'id': insertedContactId,
                        'label': insertedContact.Label,
                        'value': insertedContact.Content,
                        'status': insertedContact.Status
                    }); 

                    for(var i = requestInsertContactList.length - 1; i >= 0; i--) {
                        var contact = requestInsertContactList[i];

                        if ((contact.label === insertedContact.Label) && (contact.value === insertedContact.Content) && (contact.status === insertedContact.Status)) {
                            requestInsertContactList.splice(i, 1);
                            break;
                        }
                    }
                }
            }

            if ((requestInsertContactList.length === 0) &&
                (requestUpdateContactList.length === 0) &&
                (requestDeleteContactList.length === 0)) {

                $rootScope.$broadcast('UpdateTeacherContactInfo', $scope['originalData']['teacherId'], $scope['originalData']);

                hideDialogBox();
            }
        } else {
            onErrorInsertTeacherContactInfo(data, status, headers, config);
        }
    };

    var onErrorInsertTeacherContactInfo = function (data, status, headers, config) {
        console.log('onErrorInsertTeacherContactInfo');
    };

    var onSuccessUpdateTeacherContactInfo = function (data, status, headers, config) {
        var isSuccess = data.d;
        if (isSuccess === true) {
            var updatedContact = config.data.teacherContact;
            if (updatedContact !== null) {
                if (updatedContact.Type === Enum.ContactType.Phone) {
                    for(var i = $scope['originalData']['phones'].length - 1; i >= 0; i--) {
                        var phone = $scope['originalData']['phones'][i];

                        if (phone.id === updatedContact.Id) {
                            phone.label = updatedContact.Label;
                            phone.value = updatedContact.Content;
                            phone.status = updatedContact.Status;
                            phone.isPrimary = updatedContact.IsPrimary;
                            break;
                        }
                    }

                    for(var i = requestUpdateContactList.length - 1; i >= 0; i--) {
                        var phone = requestUpdateContactList[i];

                        if (phone.id === updatedContact.Id) {
                            requestUpdateContactList.splice(i, 1);
                            break;
                        }
                    }
                } else if (updatedContact.Type === Enum.ContactType.Email) {
                    for(var i = $scope['originalData']['emails'].length - 1; i >= 0; i--) {
                        var email = $scope['originalData']['emails'][i];

                        if (email.id === updatedContact.Id) {
                            email.label = updatedContact.Label;
                            email.value = updatedContact.Content;
                            email.status = updatedContact.Status;
                            email.isPrimary = updatedContact.IsPrimary;
                            break;
                        }
                    }

                    for(var i = requestUpdateContactList.length - 1; i >= 0; i--) {
                        var email = requestUpdateContactList[i];

                        if (email.id === updatedContact.Id) {
                            requestUpdateContactList.splice(i, 1);
                            break;
                        }
                    }
                }
            } 

            if ((requestInsertContactList.length === 0) &&
                (requestUpdateContactList.length === 0) &&
                (requestDeleteContactList.length === 0)) {

                $rootScope.$broadcast('UpdateTeacherContactInfo', $scope['originalData']['teacherId'], $scope['originalData']);

                hideDialogBox();
            }
        } else {
            onErrorUpdateTeacherContactInfo(data, status, headers, config);
        }
    };

    var onErrorUpdateTeacherContactInfo = function (data, status, headers, config) {
        $scope['isOnUpdateEdittedContactInfo'] = false;
        console.log('onErrorUpdateTeacherContactInfo');
    };

    var onSuccessDeleteTeacherContactInfo = function (data, status, headers, config) {
        var isSuccess = data.d;
        if (isSuccess === true) {
            var deletedContact = config.data.teacherContact;
            if (deletedContact !== null) {
                if (deletedContact.Type === Enum.ContactType.Phone) {
                    for(var i = $scope['originalData']['phones'].length - 1; i >= 0; i--) {
                        var phone = $scope['originalData']['phones'][i];

                        if (phone.id === deletedContact.Id) {
                            $scope['originalData']['phones'].splice(i, 1);
                            break;
                        }
                    }

                    for(var i = requestDeleteContactList.length - 1; i >= 0; i--) {
                        var phone = requestDeleteContactList[i];

                        if (phone.id === deletedContact.Id) {
                            requestDeleteContactList.splice(i, 1);
                            break;
                        }
                    }
                } else if (deletedContact.Type === Enum.ContactType.Email) {
                    for(var i = $scope['originalData']['emails'].length - 1; i >= 0; i--) {
                        var email = $scope['originalData']['emails'][i];

                        if (email.id === deletedContact.Id) {
                            $scope['originalData']['emails'].splice(i, 1);
                            break;
                        }
                    }

                    for(var i = requestDeleteContactList.length - 1; i >= 0; i--) {
                        var email = requestDeleteContactList[i];

                        if (email.id === deletedContact.Id) {
                            requestDeleteContactList.splice(i, 1);
                            break;
                        }
                    }
                }
            } 

            if ((requestInsertContactList.length === 0) &&
                (requestUpdateContactList.length === 0) &&
                (requestDeleteContactList.length === 0)) {

                $rootScope.$broadcast('UpdateTeacherContactInfo', $scope['originalData']['teacherId'], $scope['originalData']);

                hideDialogBox();
            }
        } else {
            onErrorDeleteTeacherContactInfo(data, status, headers, config);
        }
    };

    var onErrorDeleteTeacherContactInfo = function (data, status, headers, config) {
        console.log('onErrorDeleteTeacherContactInfo');
    };
};