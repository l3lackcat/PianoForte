'use strict';

goog.provide('PianoForte.Controllers.Teachers.TeacherController');

PianoForte.Controllers.Teachers.TeacherController = function ($scope, $rootScope, $routeParams, TeacherService, CourseService, Enum, EnumConverter, ValidationManager, FormatManager) {
    $scope['FormatManager'] = FormatManager;

    $scope['isReady'] = false;
    $scope['teacher'] = null;
    $scope['courseNameList'] = null;
    $scope['subDistrictList'] = null;
    $scope['districtList'] = null;
    $scope['provinceList'] = null;

    $scope['edittedGeneralInfo'] = null;
    $scope['isOnEditGeneralInfo'] = false;
    $scope['isOnUpdateEdittedGeneralInfo'] = false;

    $scope['edittedContactInfo'] = null;
    $scope['isOnEditContactInfo'] = false;
    $scope['isOnUpdateEdittedContactInfo'] = false;

    $scope['edittedAddressInfo'] = null;
    $scope['isOnEditAddressInfo'] = false;
    $scope['isOnUpdateEdittedAddressInfo'] = false;

    $scope['edittedTeachedCourseInfo'] = null;
    $scope['isOnEditTeachedCourseInfo'] = false;
    $scope['isOnUpdateEdittedTeachedCourseInfo'] = false;    

    $scope['numberOfActivePhones'] = 0;
    $scope['numberOfActiveEmails'] = 0;

    var requestInsertContactList = [];
    var requestUpdateContactList = [];
    var requestDeleteContactList = [];

    $scope.initialize = function () {
        $rootScope.$broadcast('SelectMenuItem', 'teachers');

        $scope['isReady'] = false;
        $scope['teacher'] = null;
        $scope['courseNameList'] = null;
        $scope['subDistrictList'] = null;
        $scope['districtList'] = null;
        $scope['provinceList'] = null;        

        TeacherService.getTeacherInfoById($routeParams['teacherId'], onSuccessReceiveTeacherInfoById, onErrorReceiveTeacherInfoById);
        CourseService.getCourseNameList(Enum.Status.Active, onSuccessReceiveCourseNameList, onErrorReceiveCourseNameList);
    };

    $scope.onEditGeneralInfo = function () {
        $scope['edittedGeneralInfo'] = {
            'id': {
                'value': $scope['teacher']['id'],
                'isRequired': false,
                'isValid': true
            },
            'firstname': {
                'value': $scope['teacher']['firstname'],
                'isRequired': true,
                'isValid': true
            },
            'lastname': {
                'value': $scope['teacher']['lastname'],
                'isRequired': true,
                'isValid': true
            },
            'nickname': {
                'value': $scope['teacher']['nickname'],
                'isRequired': true,
                'isValid': true
            },
            'status': {
                'value': {
                    'key': $scope['teacher']['status']['key'],
                    'text': $scope['teacher']['status']['text']
                },
                'isRequired': false,
                'isValid': true
            }
        }

        $scope['isOnEditGeneralInfo'] = true;
    };

    $scope.onEditContactInfo = function () {
        if ($scope['edittedContactInfo'] === null) {
            $scope['edittedContactInfo'] = {
                'phones': [],
                'emails': []
            };

            var phoneLength = $scope['teacher']['contacts']['phones'].length;
            for(var i = 0; i < phoneLength; i++) {
                var phone = $scope['teacher']['contacts']['phones'][i];

                $scope['edittedContactInfo']['phones'].push({
                    'id': phone.id,
                    'label': phone.label,
                    'value': phone.value.replace(/-/g, ''),
                    'status': phone.status,
                    'isPrimary': phone.isPrimary || false,
                    'isValid': true
                });
            }

            if ($scope['edittedContactInfo']['phones'].length === 0) {
                $scope.addPhone();
            }            

            var emailLength = $scope['teacher']['contacts']['emails'].length;
            for(var i = 0; i < emailLength; i++) {
                var email = $scope['teacher']['contacts']['emails'][i];

                $scope['edittedContactInfo']['emails'].push({
                    'id': email.id,
                    'label': email.label,
                    'value': email.value,
                    'status': email.status,
                    'isPrimary': email.isPrimary || false,
                    'isValid': true
                });
            }

            if ($scope['edittedContactInfo']['emails'].length === 0) {
                $scope.addEmail();
            } 

            $scope['isOnEditContactInfo'] = true;
        }            
    };

    $scope.onEditAddressInfo = function () {
        $scope['edittedAddressInfo'] = {
            'id': {
                // 'value': $scope['teacher']['address']['id'],
                'value': 0,
                'isRequired': false,
                'isValid': true
            },
            'buildingName': {
                // 'value': $scope['teacher']['address']['buildingName'],
                'value': '',
                'isRequired': true,
                'isValid': true
            },
            'streetAddress': {
                // 'value': $scope['teacher']['address']['streetAddress'],
                'value': '',
                'isRequired': true,
                'isValid': true
            },
            'subDistrict': {
                // 'value': $scope['teacher']['address']['subDistrict'],
                'value': '',
                'isRequired': true,
                'isValid': true
            },
            'district': {
                // 'value': $scope['teacher']['address']['district'],
                'value': '',
                'isRequired': true,
                'isValid': true
            },
            'province': {
                // 'value': $scope['teacher']['address']['province'],
                'value': '',
                'isRequired': true,
                'isValid': true
            },
            'postcode': {
                // 'value': $scope['teacher']['address']['postcode'],
                'value': '',
                'isRequired': true,
                'isValid': true
            }
        }

        $scope['isOnEditAddressInfo'] = true;
    };

    $scope.onEditTeachedCourseInfo = function () {
        if ($scope['edittedTeachedCourseInfo'] === null) {
            $scope['edittedTeachedCourseInfo'] = [];

            for(var i = $scope['teacher']['teachedCourses'].length - 1; i >= 0; i--) {
                var tempCourseList = [];
                var teachedCourseIndex = -1;

                var courseNameListLength = $scope['courseNameList'].length;
                for(var j = 0; j < courseNameListLength; j++) {
                    var courseName = $scope['courseNameList'][j];
                    if (courseName === $scope['teacher']['teachedCourses'][i]) {
                        teachedCourseIndex = j;
                    }

                    tempCourseList.push({
                        'id': j,
                        'text': courseName,
                        'excluded': false
                    });
                }                

                $scope['edittedTeachedCourseInfo'].push({
                    'index': $scope['edittedTeachedCourseInfo'].length,
                    'selectedId': teachedCourseIndex,
                    'courseNameList': tempCourseList
                });
            };

            if ($scope['edittedTeachedCourseInfo'].length === 0) {
                $scope.addTeachedCourse();
            }

            $scope['isOnEditTeachedCourseInfo'] = true;
        }
    };

    $scope.onSubmitEditGeneralInfo = function () {
        if (validateGeneralInfo() === true) {
            if (isGeneralInfoChanged() === true) {
                $scope['isOnUpdateEdittedGeneralInfo'] = true;
                TeacherService.updateTeacherGeneralInfo($scope['edittedGeneralInfo'], onSuccessUpdateTeacherGeneralInfo, onErrorUpdateTeacherGeneralInfo);
            } else {
                hideGeneralInfoDialogBox();
            }
        }
    };

    $scope.onCancelEditGeneralInfo = function () {
        hideGeneralInfoDialogBox();
    };

    $scope.onSubmitEditContactInfo = function () {
        if (validateContactInfo() === true) { 
            $scope['isOnUpdateEdittedContactInfo'] = true;

            for(var i = $scope['edittedContactInfo']['phones'].length - 1; i >= 0; i--) {
                var newPhone = $scope['edittedContactInfo']['phones'][i];                
                newPhone.type = Enum.ContactType.Phone;                
                newPhone.teacherId = $scope['teacher']['id'];
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
                        for(var j = $scope['teacher']['contacts']['phones'].length - 1; j >= 0; j--) {
                            var oldPhone = $scope['teacher']['contacts']['phones'][j];                        

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

            for(var i = $scope['edittedContactInfo']['emails'].length - 1; i >= 0; i--) {
                var newEmail = $scope['edittedContactInfo']['emails'][i];
                newEmail.type = Enum.ContactType.Email;
                newEmail.teacherId = $scope['teacher']['id'];
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
                        for(var j = $scope.teacher.contacts.emails.length - 1; j >= 0; j--) {
                            var oldEmail = $scope['teacher']['contacts']['emails'][j];

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

            if ((requestInsertContactList.length === 0) &&
                (requestUpdateContactList.length === 0) &&
                (requestDeleteContactList.length === 0)) {                

                hideContactInfoDialogBox();
            }
        }        
    };

    $scope.onCancelEditContactInfo = function () {
        hideContactInfoDialogBox();
    };

    $scope.onCancelEditAddressInfo = function () {
        hideAddressInfoDialogBox();
    };

    $scope.onSubmitEditTeachedCourseInfo = function () {
        var newTeachedCourseList = [];

        for(var i = $scope['edittedTeachedCourseInfo'].length - 1; i >= 0; i--) {
            var teachedCourse = $scope['edittedTeachedCourseInfo'][i];
            var selectedId = teachedCourse.selectedId;

            if (selectedId !== undefined) {
                for(var j = teachedCourse.courseNameList.length - 1; j >= 0; j--) {
                    var courseName = teachedCourse.courseNameList[j];
                    if (courseName.id === selectedId) {
                        var courseNameText = courseName.text;
                        if (newTeachedCourseList.indexOf(courseNameText) === -1) {
                            newTeachedCourseList.push(courseNameText);
                        }

                        break;
                    }
                }
            } else {
                $scope['edittedTeachedCourseInfo'].splice(i, 1);
            }                
        }

        var isDifferent = false;
        var newTeachedCourseListLength = newTeachedCourseList.length;
        var oldTeachedCourseListLength = $scope['teacher']['teachedCourses'].length;

        if (newTeachedCourseListLength !== oldTeachedCourseListLength) {
            isDifferent = true;
        } else {
            for(var i = newTeachedCourseListLength - 1; i >= 0; i--) {
                var isFound = false;
                var newTeachedCourse = newTeachedCourseList[i];

                for(var j = oldTeachedCourseListLength - 1; j >= 0; j--) {
                    var oldTeachedCourse = $scope['teacher']['teachedCourses'][j];
                    if (oldTeachedCourse === newTeachedCourse) {
                        isFound = true;
                        break;
                    }                    
                }

                if (isFound === false) {
                    isDifferent = true;
                    break;
                }
            }
        }

        if (isDifferent === true) {
            $scope['isOnUpdateEdittedTeachedCourseInfo'] = true;
            TeacherService.updateTeachedCourseInfo($scope['teacher']['id'], newTeachedCourseList, onSuccessUpdateTeachedCourseInfo, onErrorUpdateTeachedCourseInfo);
        } else {
            hideTeachedCourseInfoDialogBox();
        }
    };

    $scope.onCancelEditTeachedCourseInfo = function () {
        hideTeachedCourseInfoDialogBox();
    };

    $scope.addPhone = function () {
        var id = -1;

        for(var i = $scope['edittedContactInfo']['phones'].length - 1; i >= 0; i--) {
            var phone = $scope['edittedContactInfo']['phones'][i];
            if (phone.id < 0) {
                id--;
            }
        }

        $scope['edittedContactInfo']['phones'].push({
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
            for(var i = $scope['edittedContactInfo']['phones'].length - 1; i >= 0; i--) {
                var phone = $scope['edittedContactInfo']['phones'][i];
                if (phone.id === removedPhone.id) {
                    $scope['edittedContactInfo']['phones'].splice(i, 1);
                    break;
                }
            }                    
        } else {
            removedPhone.status = Enum.Status.Deleted;
            removedPhone.isPrimary = false;        
        } 

        var hasActivePhone = false
        for(var i = $scope['edittedContactInfo']['phones'].length - 1; i >= 0; i--) {
            var phone = $scope['edittedContactInfo']['phones'][i];
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
            for(var i = $scope['edittedContactInfo']['phones'].length - 1; i >= 0; i--) {
                var phone = $scope['edittedContactInfo']['phones'][i];
                if (phone.id !== e.name) {
                    phone.isPrimary = false;
                }
            }
        }
    };

    $scope.addEmail = function () {
        var id = -1;

        for(var i = $scope['edittedContactInfo']['emails'].length - 1; i >= 0; i--) {
            var email = $scope['edittedContactInfo']['emails'][i];
            if (email.id < 0) {
                id--;
            }
        }

        $scope['edittedContactInfo']['emails'].push({
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
            for(var i = $scope['edittedContactInfo']['emails'].length - 1; i >= 0; i--) {
                var email = $scope['edittedContactInfo']['emails'][i];
                if (email.id === removedEmail.id) {
                    $scope['edittedContactInfo']['emails'].splice(i, 1);
                    break;
                }
            }                    
        } else {
            removedEmail.status = Enum.Status.Deleted;
            removedEmail.isPrimary = false;        
        } 

        var hasActiveEmail = false
        for(var i = $scope['edittedContactInfo']['emails'].length - 1; i >= 0; i--) {
            var email = $scope['edittedContactInfo']['emails'][i];
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
            for(var i = $scope['edittedContactInfo']['emails'].length - 1; i >= 0; i--) {
                var email = $scope['edittedContactInfo']['emails'][i];
                if (email.id !== e.name) {
                    email.isPrimary = false;
                }
            }
        }
    };

    $scope.addTeachedCourse = function () {
        var tempCourseList = [];

        var courseNameListLength = $scope['courseNameList'].length;
        for(var j = 0; j < courseNameListLength; j++) {
            var courseName = $scope['courseNameList'][j];

            tempCourseList.push({
                'id': j,
                'text': courseName,
                'excluded': false
            });
        }

        $scope['edittedTeachedCourseInfo'].push({
            'index': $scope['edittedTeachedCourseInfo'].length,
            'selectedId': undefined,
            'courseNameList': tempCourseList
        });
    };

    $scope.removeTeachedCourse = function (index) {
        $scope['edittedTeachedCourseInfo'].splice(index, 1);

        if ($scope['edittedTeachedCourseInfo'].length === 0) {
            $scope.addTeachedCourse();
        }
    };    

    function hideGeneralInfoDialogBox() {
        $scope['edittedGeneralInfo'] = null;
        $scope['isOnEditGeneralInfo'] = false;
        $scope['isOnUpdateEdittedGeneralInfo'] = false;
    };

    function hideContactInfoDialogBox() {
        $scope['edittedContactInfo'] = null;
        $scope['isOnEditContactInfo'] = false;
        $scope['isOnUpdateEdittedContactInfo'] = false;

        $scope['numberOfActivePhones'] = 0;
        $scope['numberOfActiveEmails'] = 0;
    };

    function hideAddressInfoDialogBox() {
        $scope['edittedAddressInfo'] = null;
        $scope['isOnEditAddressInfo'] = false;
        $scope['isOnUpdateEdittedAddressInfo'] = false;
    }

    function hideTeachedCourseInfoDialogBox() {
        $scope['edittedTeachedCourseInfo'] = null;
        $scope['isOnEditTeachedCourseInfo'] = false;
        $scope['isOnUpdateEdittedTeachedCourseInfo'] = false;
    };

    function validateGeneralInfo() {
        var isValid = true;

        if ($scope['edittedGeneralInfo']['firstname']['value'] === '') {
            $scope['edittedGeneralInfo']['firstname']['isValid'] = false;
            isValid = false;
        } else {
            $scope['edittedGeneralInfo']['firstname']['isValid'] = true;
        }

        if ($scope['edittedGeneralInfo']['lastname']['value'] === '') {
            $scope['edittedGeneralInfo']['lastname']['isValid'] = false;
            isValid = false;
        } else {
            $scope['edittedGeneralInfo']['lastname']['isValid'] = true;
        }

        if ($scope['edittedGeneralInfo']['nickname']['value'] === '') {
            $scope['edittedGeneralInfo']['nickname']['isValid'] = false;
            isValid = false;
        } else {
            $scope['edittedGeneralInfo']['nickname']['isValid'] = true;
        }

        return isValid;
    };

    function isGeneralInfoChanged() {
        var isChanged = false;

        if (($scope['teacher']['firstname'] !== $scope['edittedGeneralInfo']['firstname']['value']) ||
            ($scope['teacher']['lastname'] !== $scope['edittedGeneralInfo']['lastname']['value']) ||
            ($scope['teacher']['nickname'] !== $scope['edittedGeneralInfo']['nickname']['value'])) {
            isChanged = true;
        }

        return isChanged;
    };            

    function validateContactInfo() {
        var isValid = true;

        var numberOfActivePhones = $scope['edittedContactInfo']['phones'].length;
        for(var i = $scope['edittedContactInfo']['phones'].length - 1; i >= 0; i--) {
            var phone = $scope['edittedContactInfo']['phones'][i];
            phone.isValid = true;

            if (phone.id > 0) {
                if (phone.status === Enum.Status.Active) {
                    if (ValidationManager.isPhoneNumber(phone.value) === false) {
                        phone.isValid = false;
                        isValid = false;
                    }
                } else {
                    numberOfActivePhones--;
                }                                
            } else {
                if (phone.value !== '') {
                    if (ValidationManager.isPhoneNumber(phone.value) === false) {
                        phone.isValid = false;
                        isValid = false;
                    }
                } else {
                    $scope['edittedContactInfo']['phones'].splice(i, 1);
                    numberOfActivePhones--;
                }               
            }
        }

        var numberOfActiveEmails = $scope['edittedContactInfo']['emails'].length;
        for(var i = $scope['edittedContactInfo']['emails'].length - 1; i >= 0; i--) {
            var email = $scope['edittedContactInfo']['emails'][i];
            email.isValid = true;

            if (email.id > 0) {
                if (email.status === Enum.Status.Active) {
                    if (ValidationManager.isEmail(email.value) === false) {
                        email.isValid = false;
                        isValid = false;
                    } 
                } else {
                    numberOfActiveEmails--;
                }
            } else {
                if (email.value !== '') {
                    if (ValidationManager.isEmail(email.value) === false) {
                        email.isValid = false;
                        isValid = false;
                    }
                } else {
                    $scope['edittedContactInfo']['emails'].splice(i, 1);
                    numberOfActiveEmails--;
                }
            }
        }

        $scope['numberOfActivePhones'] = numberOfActivePhones;
        $scope['numberOfActiveEmails'] = numberOfActiveEmails;

        return isValid;
    };

    var onSuccessReceiveTeacherInfoById = function (data, status, headers, config) {
        var tempTeacher = data.d;

        if (tempTeacher !== null) {
            $scope['teacher'] = {
                'id': tempTeacher.id,
                'firstname': tempTeacher.firstname,
                'lastname': tempTeacher.lastname,
                'nickname': tempTeacher.nickname,
                'status': {
                    'key': tempTeacher.status,
                    'text': EnumConverter.Status.toString(tempTeacher.status)
                },
                'contacts': {
                    'phones': tempTeacher.phoneList,
                    'emails': tempTeacher.emailList
                },
                'teachedCourses': tempTeacher.teachedCourseList
            };

            for(var i = $scope['teacher']['contacts']['phones'].length - 1; i >= 0; i--) {
                var phone = $scope['teacher']['contacts']['phones'][i];
                phone.value = FormatManager.unformatPhoneNumber(phone.value);
            };

            if ($scope['courseNameList'] !== null) {
                $scope['isReady'] = true;
            }            
        }
    };

    var onErrorReceiveTeacherInfoById = function (data, status, headers, config) {
        console.log('onErrorReceiveTeacherInfoById');
    };

    var onSuccessReceiveCourseNameList = function (data, status, headers, config) {
        if (data.d !== null) {
            $scope['courseNameList'] = data.d;

            if ($scope['teacher'] !== null) {
                $scope['isReady'] = true;
            }
        }
    };

    var onErrorReceiveCourseNameList = function (data, status, headers, config) {
        console.log('onErrorReceiveCourseNameList');
    };

    var onSuccessUpdateTeacherGeneralInfo = function (data, status, headers, config) {
        var isSuccess = data.d;

        if (isSuccess === true) {
            $scope['teacher']['firstname'] = $scope['edittedGeneralInfo']['firstname']['value'];
            $scope['teacher']['lastname'] = $scope['edittedGeneralInfo']['lastname']['value'];
            $scope['teacher']['nickname'] = $scope['edittedGeneralInfo']['nickname']['value'];

            hideGeneralInfoDialogBox();
        } else {
            onErrorUpdateTeacherGeneralInfo(data, status, headers, config);
        }        
    };

    var onErrorUpdateTeacherGeneralInfo = function (data, status, headers, config) {
        $scope['isOnUpdateEdittedGeneralInfo'] = false;
        console.log('onErrorUpdateTeacherGeneralInfo');
    };

    var onSuccessInsertTeacherContactInfo = function (data, status, headers, config) {
        var insertedContactId = data.d;
        if (insertedContactId > 0) {
            var insertedContact = config.data.teacherContact;
            if (insertedContact !== null) {
                if (insertedContact.Type === Enum.ContactType.Phone) {
                    $scope['teacher']['contacts']['phones'].push({
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
                    $scope['teacher']['contacts']['emails'].push({
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

                hideContactInfoDialogBox();
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
                    for(var i = $scope['teacher']['contacts']['phones'].length - 1; i >= 0; i--) {
                        var phone = $scope['teacher']['contacts']['phones'][i];

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
                    for(var i = $scope['teacher']['contacts']['emails'].length - 1; i >= 0; i--) {
                        var email = $scope['teacher']['contacts']['emails'][i];

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

                hideContactInfoDialogBox();
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
                    for(var i = $scope['teacher']['contacts']['phones'].length - 1; i >= 0; i--) {
                        var phone = $scope['teacher']['contacts']['phones'][i];

                        if (phone.id === deletedContact.Id) {
                            $scope['teacher']['contacts']['phones'].splice(i, 1);
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
                    for(var i = $scope['teacher']['contacts']['emails'].length - 1; i >= 0; i--) {
                        var email = $scope['teacher']['contacts']['emails'][i];

                        if (email.id === deletedContact.Id) {
                            $scope['teacher']['contacts']['emails'].splice(i, 1);
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

                hideContactInfoDialogBox();
            }
        } else {
            onErrorDeleteTeacherContactInfo(data, status, headers, config);
        }
    };

    var onErrorDeleteTeacherContactInfo = function (data, status, headers, config) {
        console.log('onErrorDeleteTeacherContactInfo');
    };

    var onSuccessUpdateTeachedCourseInfo = function (data, status, headers, config) {
        var isSuccess = data.d;
        if (isSuccess === true) {
            $scope['teacher']['teachedCourses'] = config.data.teachedCourseNameList;

            hideTeachedCourseInfoDialogBox();
        } else {
            onErrorUpdateTeachedCourseInfo(data, status, headers, config);
        }
    };

    var onErrorUpdateTeachedCourseInfo = function (data, status, headers, config) {
        console.log('onErrorUpdateTeachedCourseInfo');
    };
};