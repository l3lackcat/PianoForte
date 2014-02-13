'use strict';

goog.provide('PianoForte.Controllers.Teachers.TeacherController');

PianoForte.Controllers.Teachers.TeacherController = function ($scope, $rootScope, $routeParams, TeacherService, Enum, EnumConverter, ValidationService) {
    $scope.isReady = false;
    $scope.teacher = null;

    $scope.edittedGeneralInfo = null;
    $scope.isOnEditGeneralInfo = false;
    $scope.isOnUpdateEdittedGeneralInfo = false;

    $scope.edittedContactInfo = null;
    $scope.isOnEditContactInfo = false;
    $scope.isOnUpdateEdittedContactInfo = false;

    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'teachers');

        $scope.isReady = false;
        $scope.teacher = {
            id: '',
            firstname: '',
            lastname: '',
            nickname: '',
            status: {
                key: '',
                text: ''
            },
            contacts: {
                phones: [],
                emails: []
            },
            teachedCourses: []
        };

        TeacherService.getTeacherInfoById($routeParams.teacherId, onSuccessReceiveTeacherInfoById, onErrorReceiveTeacherInfoById);
    };

    $scope.onEditGeneralInfo = function () {
        $scope.edittedGeneralInfo = {
            id: {
                value: $scope.teacher.id,
                isRequired: false,
                isValid: true
            },
            firstname: {
                value: $scope.teacher.firstname,
                isRequired: true,
                isValid: true
            },
            lastname: {
                value: $scope.teacher.lastname,
                isRequired: true,
                isValid: true
            },
            nickname: {
                value: $scope.teacher.nickname,
                isRequired: false,
                isValid: true
            },
            status: {
                value: {
                    key: $scope.teacher.status.key,
                    text: $scope.teacher.status.text
                },
                isRequired: false,
                isValid: true
            }
        }

        $scope.isOnEditGeneralInfo = true;
    };

    $scope.onSubmitEditGeneralInfo = function () {
        if (validateGeneralInfo() === true) {
            if (isGeneralInfoChanged() === true) {
                $scope.isOnUpdateEdittedGeneralInfo = true;
                TeacherService.updateTeacherGeneralInfo($scope.edittedGeneralInfo, onSuccessUpdateTeacherGeneralInfo, onErrorUpdateTeacherGeneralInfo);
            } else {
                hideGeneralInfoDialogBox();
            }
        }
    };

    $scope.onCancelEditGeneralInfo = function () {
        hideGeneralInfoDialogBox();
    };

    function hideGeneralInfoDialogBox() {
        $scope.edittedGeneralInfo = null;
        $scope.isOnEditGeneralInfo = false;
        $scope.isOnUpdateEdittedGeneralInfo = false;
    };

    function validateGeneralInfo() {
        var isValid = true;

        if ($scope.edittedGeneralInfo.firstname.value === '') {
            $scope.edittedGeneralInfo.firstname.isValid = false;
            isValid = false;
        } else {
            $scope.edittedGeneralInfo.firstname.isValid = true;
        }

        if ($scope.edittedGeneralInfo.lastname.value === '') {
            $scope.edittedGeneralInfo.lastname.isValid = false;
            isValid = false;
        } else {
            $scope.edittedGeneralInfo.lastname.isValid = true;
        }

        return isValid;
    };

    function isGeneralInfoChanged() {
        var isChanged = false;

        if (($scope.teacher.firstname !== $scope.edittedGeneralInfo.firstname.value) ||
            ($scope.teacher.lastname !== $scope.edittedGeneralInfo.lastname.value) ||
            ($scope.teacher.nickname !== $scope.edittedGeneralInfo.nickname.value)) {
            isChanged = true;
        }

        return isChanged;
    };

    $scope.onEditContactInfo = function () {
        $scope.edittedContactInfo = {
            phones: [],
            emails: []
        };

        var phoneLength = $scope.teacher.contacts.phones.length;
        for (var i = 0; i < phoneLength; i++) {
            var phone = $scope.teacher.contacts.phones[i];

            $scope.edittedContactInfo.phones.push({
                id: phone.id,
                label: phone.label,
                value: phone.value.replace(/-/g, ''),
                status: phone.status,
                isValid: true
            });
        }

        var emailLength = $scope.teacher.contacts.emails.length;
        for (var i = 0; i < emailLength; i++) {
            var email = $scope.teacher.contacts.emails[i];

            $scope.edittedContactInfo.emails.push({
                id: email.id,
                label: email.label,
                value: email.value,
                status: email.status,
                isValid: true
            });
        }

        $scope.isOnEditContactInfo = true;
    };

    $scope.onSubmitEditContactInfo = function () {
        if (validateContactInfo() === true) { 
            $scope.isOnUpdateEdittedContactInfo = true;

            for (var i = $scope.edittedContactInfo.phones.length - 1; i >= 0; i--) {
                var newPhone = $scope.edittedContactInfo.phones[i];
                newPhone.type = Enum.ContactType.Phone;
                newPhone.teacherId = $scope.teacher.id;

                if (newPhone.id === 0) {
                    if (newPhone.value !== '') {
                        // Insert new phone                        
                        TeacherService.insertTeacherContactInfo(newPhone, onSuccessInsertTeacherContactInfo, onErrorInsertTeacherContactInfo);
                    }                        
                } else {
                    if (newPhone.status === Enum.Status.Deleted) {
                        // Delete new phone
                        TeacherService.deleteTeacherContactInfo(newPhone.id, onSuccessDeleteTeacherContactInfo, onErrorDeleteTeacherContactInfo);
                    } else {
                        var isEditted = false;

                        for (var j = $scope.teacher.contacts.phones.length - 1; j >= 0; j--) {
                            var oldPhone = $scope.teacher.contacts.phones[j];                        

                            if ((oldPhone.id === newPhone.id)) {
                                var newPhoneValue = newPhone.value.replace(/-/g, '');
                                var oldPhoneValue = oldPhone.value.replace(/-/g, '');

                                if ((oldPhone.label !== newPhone.label) || (oldPhoneValue !== newPhoneValue)) {
                                    // Update phone
                                    isEditted = true;
                                    TeacherService.updateTeacherContactInfo(newPhone, onSuccessUpdateTeacherContactInfo, onErrorUpdateTeacherContactInfo);
                                }

                                break;
                            }
                        }

                        if (isEditted === false) {
                            $scope.edittedContactInfo.phones.splice(i, 1);
                        }
                    }                        
                }                    
            }; 

            for (var i = $scope.edittedContactInfo.emails.length - 1; i >= 0; i--) {
                var newEmail = $scope.edittedContactInfo.emails[i];
                newEmail.type = Enum.ContactType.Email;
                newEmail.teacherId = $scope.teacher.id;

                if (newEmail.id === 0) {
                    if (newEmail.value !== '') {
                        // Insert new phone                        
                        TeacherService.insertTeacherContactInfo(newEmail, onSuccessInsertTeacherContactInfo, onErrorInsertTeacherContactInfo);
                    }                        
                } else {
                    if (newEmail.status === Enum.Status.Deleted) {
                        // Delete new phone
                        TeacherService.deleteTeacherContactInfo(newEmail.id, onSuccessDeleteTeacherContactInfo, onErrorDeleteTeacherContactInfo);
                    } else {
                        var isEditted = false;

                        for (var j = $scope.teacher.contacts.emails.length - 1; j >= 0; j--) {
                            var oldEmail = $scope.teacher.contacts.emails[j];

                            if ((oldEmail.id === newEmail.id)) {
                                var newEmailValue = newEmail.value.replace(/-/g, '');
                                var oldEmailValue = oldEmail.value.replace(/-/g, '');

                                if ((oldEmail.label !== newEmail.label) || (oldEmailValue !== newEmailValue)) {
                                    // Update phone
                                    isEditted = true;
                                    TeacherService.updateTeacherContactInfo(newEmail, onSuccessUpdateTeacherContactInfo, onErrorUpdateTeacherContactInfo);
                                }

                                break;
                            }
                        }

                        if (isEditted === false) {
                            $scope.edittedContactInfo.emails.splice(i, 1);
                        }
                    }                        
                }                    
            };                      
        }

        if (($scope.edittedContactInfo.phones.length === 0) &&
            ($scope.edittedContactInfo.emails.length === 0)) {                

            hideContactInfoDialogBox();
        }
    };

    $scope.onCancelEditContactInfo = function () {
        hideContactInfoDialogBox();
    };

    $scope.addPhone = function () {
        $scope.edittedContactInfo.phones.push({
            id: 0,
            label: '',
            value: '',
            status: Enum.Status.Active,
            isValid: true
        });
    };

    $scope.removePhone = function (phone) {
        phone.status = Enum.Status.Deleted;
    };

    $scope.addEmail = function () {
        $scope.edittedContactInfo.emails.push({
            id: 0,
            label: '',
            value: '',
            status: Enum.Status.Active,
            isValid: true
        });
    };

    $scope.removeEmail = function (email) {
        email.status = Enum.Status.Deleted;
    };

    function hideContactInfoDialogBox() {
        $scope.edittedContactInfo = null;
        $scope.isOnEditContactInfo = false;
        $scope.isOnUpdateEdittedContactInfo = false;
    };

    function validateContactInfo() {
        var isValid = true;

        for (var i = $scope.edittedContactInfo.phones.length - 1; i >= 0; i--) {
            var phone = $scope.edittedContactInfo.phones[i];
            phone.isValid = true;

            if (phone.id > 0) {
                if (phone.status === Enum.Status.Active) {
                    if (ValidationService.isPhoneNumber(phone.value) === false) {
                        phone.isValid = false;
                        isValid = false;
                    }
                }                                
            } else {
                if (phone.value !== '') {
                    if (ValidationService.isPhoneNumber(phone.value) === false) {
                        phone.isValid = false;
                        isValid = false;
                    }
                }               
            }
        };

        for (var i = $scope.edittedContactInfo.emails.length - 1; i >= 0; i--) {
            var email = $scope.edittedContactInfo.emails[i];
            email.isValid = true;

            if (email.id > 0) {
                if (email.status === Enum.Status.Active) {
                    if (ValidationService.isEmail(email.value) === false) {
                        email.isValid = false;
                        isValid = false;
                    } 
                }
            } else {
                if (email.value !== '') {
                    if (ValidationService.isEmail(email.value) === false) {
                        email.isValid = false;
                        isValid = false;
                    }
                }
            }
        };

        return isValid;
    };

    var onSuccessReceiveTeacherInfoById = function (data, status, headers, config) {
        var tempTeacher = data.d;

        if (tempTeacher !== null) {
            $scope.teacher.id = tempTeacher.id;
            $scope.teacher.firstname = tempTeacher.firstname;
            $scope.teacher.lastname = tempTeacher.lastname;
            $scope.teacher.nickname = tempTeacher.nickname;
            $scope.teacher.contacts.phones = tempTeacher.phoneList;
            $scope.teacher.contacts.emails = tempTeacher.emailList;
            $scope.teacher.teachedCourses = tempTeacher.teachedCourseList;

            $scope.teacher.status.key = tempTeacher.status;
            $scope.teacher.status.text = EnumConverter.Status.toString(tempTeacher.status);

            $scope.isReady = true;
        }
    };

    var onErrorReceiveTeacherInfoById = function (data, status, headers, config) {
        console.log('onErrorReceiveTeacherInfoById');
    };

    var onSuccessUpdateTeacherGeneralInfo = function (data, status, headers, config) {
        var isSuccess = data.d;

        if (isSuccess === true) {
            $scope.teacher.firstname = $scope.edittedGeneralInfo.firstname.value;
            $scope.teacher.lastname = $scope.edittedGeneralInfo.lastname.value;
            $scope.teacher.nickname = $scope.edittedGeneralInfo.nickname.value;

            hideGeneralInfoDialogBox();
        } else {
            onErrorUpdateTeacherGeneralInfo(data, status, headers, config);
        }        
    };

    var onErrorUpdateTeacherGeneralInfo = function (data, status, headers, config) {
        $scope.isOnUpdateEdittedGeneralInfo = false;
        console.log('onErrorUpdateTeacherGeneralInfo');
    };

    var onSuccessInsertTeacherContactInfo = function (data, status, headers, config) {
        console.log('onSuccessInsertTeacherContactInfo');
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
                    for (var i = $scope.teacher.contacts.phones.length - 1; i >= 0; i--) {
                        var phone = $scope.teacher.contacts.phones[i];

                        if (phone.id === updatedContact.Id) {
                            phone.label = updatedContact.Label;
                            phone.value = updatedContact.Content;
                            phone.status = updatedContact.Status;

                            break;
                        }
                    }

                    for (var i = $scope.edittedContactInfo.phones.length - 1; i >= 0; i--) {
                        var phone = $scope.edittedContactInfo.phones[i];

                        if (phone.id === updatedContact.Id) {
                            $scope.edittedContactInfo.phones.splice(i, 1);

                            break;
                        }
                    }
                } else if (updatedContact.Type === Enum.ContactType.Email) {
                    for (var i = $scope.teacher.contacts.emails.length - 1; i >= 0; i--) {
                        var email = $scope.teacher.contacts.emails[i];

                        if (email.id === updatedContact.Id) {
                            email.label = updatedContact.Label;
                            email.value = updatedContact.Content;
                            email.status = updatedContact.Status;

                            break;
                        }
                    }

                    for (var i = $scope.edittedContactInfo.emails.length - 1; i >= 0; i--) {
                        var email = $scope.edittedContactInfo.emails[i];

                        if (email.id === updatedContact.Id) {
                            $scope.edittedContactInfo.emails.splice(i, 1);

                            break;
                        }
                    }
                }
            } 

            if (($scope.edittedContactInfo.phones.length === 0) &&
                ($scope.edittedContactInfo.emails.length === 0)) {                

                hideContactInfoDialogBox();
            }
        } else {
            onErrorUpdateTeacherContactInfo(data, status, headers, config);
        }
    };

    var onErrorUpdateTeacherContactInfo = function (data, status, headers, config) {
        $scope.isOnUpdateEdittedContactInfo = false;
        console.log('onErrorUpdateTeacherContactInfo');
    };

    var onSuccessDeleteTeacherContactInfo = function (data, status, headers, config) {
        console.log('onSuccessDeleteTeacherContactInfo');
    };

    var onErrorDeleteTeacherContactInfo = function (data, status, headers, config) {
        console.log('onErrorDeleteTeacherContactInfo');
    };
};