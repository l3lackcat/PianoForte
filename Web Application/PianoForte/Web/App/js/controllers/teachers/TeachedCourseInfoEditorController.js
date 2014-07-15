'use strict';

goog.provide('PianoForte.Controllers.Teachers.TeachedCourseInfoEditorController');

PianoForte.Controllers.Teachers.TeachedCourseInfoEditorController = function ($scope, $rootScope, TeacherService, Enum, EnumConverter, FormatManager, ValidationManager) {
	$scope['edittedData'] = null;
	$scope['visible'] = false;
	$scope['isOnUpdateEdittedData'] = false;

	var _teacherId = null;
	var _teachedCourseList = null;
	var _courseNameList = null;

	$scope.$on('EditTeacherTeachedCourseInfo', function (scope, teacherId, teachedCourseList, courseNameList) {
		$scope['edittedData'] = [];

		_teacherId = teacherId;
		_teachedCourseList = teachedCourseList;
		_courseNameList = courseNameList;		

		for(var i = _teachedCourseList.length - 1; i >= 0; i--) {
			var tempCourseList = [];
			var teachedCourseIndex = -1;

			var courseNameListLength = _courseNameList.length;
			for(var j = 0; j < courseNameListLength; j++) {
				var courseName = _courseNameList[j];
				if (courseName === _teachedCourseList[i]) {
					teachedCourseIndex = j;
				}

				tempCourseList.push({
					'id': j,
					'text': courseName,
					'excluded': false
				});
			}                

			$scope['edittedData'].push({
				'index': $scope['edittedData'].length,
				'selectedId': teachedCourseIndex,
				'courseNameList': tempCourseList
			});
		};

		if ($scope['edittedData'].length === 0) {
			$scope.addTeachedCourse();
		}

		$scope['visible'] = true;        
	} .bind(this), true);

	$scope.submit = function () {
		var newTeachedCourseList = getNewTeachedCourseList();
        var isDifferent = compare(_teachedCourseList, newTeachedCourseList);
               
        if (isDifferent === true) {
            $scope['isOnUpdateEdittedData'] = true;
            TeacherService.updateTeachedCourseInfo(_teacherId, newTeachedCourseList, onSuccessUpdateTeachedCourseInfo, onErrorUpdateTeachedCourseInfo);
        } else {
            hideDialogBox();
        }
    };

    $scope.cancel = function () {
        hideDialogBox();
    };    

    $scope.addTeachedCourse = function () {
        var tempCourseList = [];

        var courseNameListLength = _courseNameList.length;
        for(var j = 0; j < courseNameListLength; j++) {
            var courseName = _courseNameList[j];

            tempCourseList.push({
                'id': j,
                'text': courseName,
                'excluded': false
            });
        }

        $scope['edittedData'].push({
            'index': $scope['edittedData'].length,
            'selectedId': undefined,
            'courseNameList': tempCourseList
        });
    };

    $scope.removeTeachedCourse = function(index) {
        $scope['edittedData'].splice(index, 1);

        if ($scope['edittedData'].length === 0) {
            $scope.addTeachedCourse();
        }
    };

    function getNewTeachedCourseList () {
    	var newTeachedCourseList = [];

        for(var i = $scope['edittedData'].length - 1; i >= 0; i--) {
            var teachedCourse = $scope['edittedData'][i];
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
                $scope['edittedData'].splice(i, 1);
            }                
        }

        return newTeachedCourseList;
    };

    function hideDialogBox () {
        $scope['edittedData'] = null;
		$scope['visible'] = false;
		$scope['isOnUpdateEdittedData'] = false;

		var _teacherId = null;
		var _teachedCourseList = null;
		var _courseNameList = null;
    };

    function compare(oldTeachedCourseList, newTeachedCourseList) {
    	var isDifferent = false;
    	var oldTeachedCourseListLength = oldTeachedCourseList.length;
    	var newTeachedCourseListLength = newTeachedCourseList.length;        

        if (oldTeachedCourseListLength !== newTeachedCourseListLength) {
            isDifferent = true;
        } else {
            for(var i = newTeachedCourseListLength - 1; i >= 0; i--) {
                var isFound = false;
                var newTeachedCourse = newTeachedCourseList[i];

                for(var j = oldTeachedCourseListLength - 1; j >= 0; j--) {
                    var oldTeachedCourse = oldTeachedCourseList[j];
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

        return isDifferent;
    }

    var onSuccessUpdateTeachedCourseInfo = function(data, status, headers, config) {
        var isSuccess = data.d;
        if (isSuccess === true) {
            $rootScope.$broadcast('UpdateTeacherTeachedCourseInfo', _teacherId, config.data.teachedCourseNameList);

            hideDialogBox();
        } else {
            onErrorUpdateTeachedCourseInfo(data, status, headers, config);
        }
    };

    var onErrorUpdateTeachedCourseInfo = function(data, status, headers, config) {
        console.log('onErrorUpdateTeachedCourseInfo');
    };
};