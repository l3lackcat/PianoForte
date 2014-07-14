'use strict';

goog.provide('PianoForte.Controllers.Teachers.TeacherController');

PianoForte.Controllers.Teachers.TeacherController = function ($scope, $rootScope, $routeParams, TeacherService, CourseService, Enum, EnumConverter, FormatManager, ValidationManager) {
    $scope['EnumConverter'] = EnumConverter;
    $scope['FormatManager'] = FormatManager;

    $scope['isReady'] = false;
    $scope['teacher'] = null;
    $scope['courseNameList'] = null;
    $scope['subDistrictList'] = null;
    $scope['districtList'] = null;
    $scope['provinceList'] = null;

    $scope['edittedAddressInfo'] = null;
    $scope['isOnEditAddressInfo'] = false;
    $scope['isOnUpdateEdittedAddressInfo'] = false;

    $scope['edittedTeachedCourseInfo'] = null;
    $scope['isOnEditTeachedCourseInfo'] = false;
    $scope['isOnUpdateEdittedTeachedCourseInfo'] = false;    

    $scope['numberOfActivePhones'] = 0;
    $scope['numberOfActiveEmails'] = 0;

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
        $rootScope.$broadcast('EditTeacherGeneralInfo', $scope['teacher']);
    };

    $scope.$on('UpdateTeacherGeneralInfo', function (scope, teacher) {
        if ($scope['teacher'] !== null) {
            $scope['teacher']['firstname'] = teacher.firstname;
            $scope['teacher']['lastname'] = teacher.lastname;
            $scope['teacher']['nickname'] = teacher.nickname;
            $scope['teacher']['status'] = teacher.status;
        }            
    } .bind(this), true);

    $scope.onEditContactInfo = function () {
        $rootScope.$broadcast('EditTeacherContactInfo', $scope['teacher']['id'], $scope['teacher']['contacts']);                
    };

    $scope.$on('UpdateTeacherContactInfo', function (scope, teacherId, contacts) {
        if ($scope['teacher'] !== null) {
            if ($scope['teacher']['id'] === teacherId) {
                $scope['teacher']['contacts']['emails'] = contacts.emails;
                $scope['teacher']['contacts']['phones'] = contacts.phones;
            }
        }            
    } .bind(this), true);

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

    var onSuccessReceiveTeacherInfoById = function (data, status, headers, config) {
        var tempTeacher = data.d;

        if (tempTeacher !== null) {
            $scope['teacher'] = {
                'id': tempTeacher.id,
                'firstname': tempTeacher.firstname,
                'lastname': tempTeacher.lastname,
                'nickname': tempTeacher.nickname,
                'status': tempTeacher.status,
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