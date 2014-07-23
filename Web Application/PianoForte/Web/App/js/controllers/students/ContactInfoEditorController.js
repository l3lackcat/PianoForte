'use strict';

goog.provide('PianoForte.Controllers.Students.ContactInfoEditorController');

PianoForte.Controllers.Students.ContactInfoEditorController = function ($scope, $rootScope, StudentService, Enum, EnumConverter, FormatManager, ValidationManager) {
	$scope['Enum'] = Enum;

	$scope['edittedData'] = null;
	$scope['visible'] = false;
	$scope['isOnUpdateEdittedData'] = false;
	$scope['numberOfActivePhones'] = 0;
	$scope['numberOfActiveEmails'] = 0;

	var _studentId = null;
	var _contacts = null;
	var _requestInsertContactList = [];
	var _requestUpdateContactList = [];
	var _requestDeleteContactList = [];

	$scope.$on('EditStudentContactInfo', function (scope, studentId, contacts) {
		_studentId = studentId;
		_contacts = contacts;

		$scope['edittedData'] = {
			'phones': [],
			'emails': []
		};

		var phoneLength = _contacts.phones.length;
		for(var i = 0; i < phoneLength; i++) {
			var phone = _contacts.phones[i];

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

		var emailLength = _contacts.emails.length;
		for(var i = 0; i < emailLength; i++) {
			var email = _contacts.emails[i];

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

	$scope.cancel = function () {
		hideDialogBox();
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
	
	$scope.removeEmail = function(removedEmail) {
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

	$scope.submit = function () {
		if (validateEdittedData() === true) { 
			$scope['isOnUpdateEdittedData'] = true;        

			submitEmails();
			submitPhones();

			if ((_requestInsertContactList.length === 0) &&
				(_requestUpdateContactList.length === 0) &&
				(_requestDeleteContactList.length === 0)) {                

				hideDialogBox();
			}
		}
	};

	function hideDialogBox() {
		_contacts = null;
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
			newEmail.studentId = _studentId;
			if (newEmail.label === '') {
				newEmail.label = 'อีเมล์'
			}

			if (newEmail.id < 0) {
				if (newEmail.status !== Enum.Status.Deleted) {
					if (newEmail.value !== '') {
						// Insert new phone   
						_requestInsertContactList.push(newEmail);                      
						StudentService.insertStudentContactInfo(newEmail, onSuccessInsertStudentContactInfo, onErrorInsertStudentContactInfo);
					}
				}                        
			} else {
				if (newEmail.status === Enum.Status.Deleted) {
					// Delete new phone
					_requestDeleteContactList.push(newEmail);
					StudentService.deleteStudentContactInfo(newEmail, onSuccessDeleteStudentContactInfo, onErrorDeleteStudentContactInfo);
				} else {
					for(var j = _contacts.emails.length - 1; j >= 0; j--) {
						var oldEmail = _contacts.emails[j];

						if ((oldEmail.id === newEmail.id)) {
							if ((oldEmail.label !== newEmail.label) || (oldEmail.value !== newEmail.value) || (oldEmail.isPrimary !== newEmail.isPrimary)) {
								// Update phone
								_requestUpdateContactList.push(newEmail);
								StudentService.updateStudentContactInfo(newEmail, onSuccessUpdateStudentContactInfo, onErrorUpdateStudentContactInfo);
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
			newPhone.studentId = _studentId;
			newPhone.value = FormatManager.unformatPhoneNumber(newPhone.value);
			if (newPhone.label === '') {
				newPhone.label = 'เบอร์โทร'
			}

			if (newPhone.id < 0) {
				if (newPhone.status !== Enum.Status.Deleted) {
					if (newPhone.value !== '') {
						// Insert new phone                    
						_requestInsertContactList.push(newPhone);                    
						StudentService.insertStudentContactInfo(newPhone, onSuccessInsertStudentContactInfo, onErrorInsertStudentContactInfo);
					}
				}                        
			} else {
				if (newPhone.status === Enum.Status.Deleted) {
					// Delete new phone
					_requestDeleteContactList.push(newPhone);
					StudentService.deleteStudentContactInfo(newPhone, onSuccessDeleteStudentContactInfo, onErrorDeleteStudentContactInfo);
				} else {
					for(var j = _contacts.phones.length - 1; j >= 0; j--) {
						var oldPhone = _contacts.phones[j];                        

						if ((oldPhone.id === newPhone.id)) {
							if ((oldPhone.label !== newPhone.label) || (oldPhone.value !== newPhone.value) || (oldPhone.isPrimary !== newPhone.isPrimary)) {
								// Update phone
								_requestUpdateContactList.push(newPhone);
								StudentService.updateStudentContactInfo(newPhone, onSuccessUpdateStudentContactInfo, onErrorUpdateStudentContactInfo);
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

	var onSuccessDeleteStudentContactInfo = function(data, status, headers, config) {
		var isSuccess = data.d;
		if (isSuccess === true) {
			var deletedContact = config.data.studentContact;
			if (deletedContact !== null) {
				if (deletedContact.Type === Enum.ContactType.Phone) {
					for(var i = _contacts.phones.length - 1; i >= 0; i--) {
						var phone = _contacts.phones[i];

						if (phone.id === deletedContact.Id) {
							_contacts.phones.splice(i, 1);
							break;
						}
					}

					for(var i = _requestDeleteContactList.length - 1; i >= 0; i--) {
						var phone = _requestDeleteContactList[i];

						if (phone.id === deletedContact.Id) {
							_requestDeleteContactList.splice(i, 1);
							break;
						}
					}
				} else if (deletedContact.Type === Enum.ContactType.Email) {
					for(var i = _contacts.emails.length - 1; i >= 0; i--) {
						var email = _contacts.emails[i];

						if (email.id === deletedContact.Id) {
							_contacts.emails.splice(i, 1);
							break;
						}
					}

					for(var i = _requestDeleteContactList.length - 1; i >= 0; i--) {
						var email = _requestDeleteContactList[i];

						if (email.id === deletedContact.Id) {
							_requestDeleteContactList.splice(i, 1);
							break;
						}
					}
				}
			} 

			if ((_requestInsertContactList.length === 0) &&
				(_requestUpdateContactList.length === 0) &&
				(_requestDeleteContactList.length === 0)) {

				$rootScope.$broadcast('UpdateStudentContactInfo', _studentId, _contacts);

				hideDialogBox();
			}
		} else {
			onErrorDeleteStudentContactInfo(data, status, headers, config);
		}
	};

	var onErrorDeleteStudentContactInfo = function(data, status, headers, config) {
		$scope['isOnUpdateEdittedData'] = false;
		console.log('onErrorDeleteStudentContactInfo');
	};

	var onSuccessInsertStudentContactInfo = function(data, status, headers, config) {
		var insertedContactId = data.d;
		if (insertedContactId > 0) {
			var insertedContact = config.data.studentContact;
			if (insertedContact !== null) {
				if (insertedContact.Type === Enum.ContactType.Phone) {
					_contacts.phones.push({
						'id': insertedContactId,
						'label': insertedContact.Label,
						'value': insertedContact.Content,
						'status': insertedContact.Status,
						'isPrimary': insertedContact.IsPrimary
					});

					for(var i = _requestInsertContactList.length - 1; i >= 0; i--) {
						var contact = _requestInsertContactList[i];

						if ((contact.label === insertedContact.Label) && (contact.value === insertedContact.Content) && (contact.status === insertedContact.Status)) {
							_requestInsertContactList.splice(i, 1);
							break;
						}
					}
				} else if (insertedContact.Type === Enum.ContactType.Email) {
					_contacts.emails.push({
						'id': insertedContactId,
						'label': insertedContact.Label,
						'value': insertedContact.Content,
						'status': insertedContact.Status
					}); 

					for(var i = _requestInsertContactList.length - 1; i >= 0; i--) {
						var contact = _requestInsertContactList[i];

						if ((contact.label === insertedContact.Label) && (contact.value === insertedContact.Content) && (contact.status === insertedContact.Status)) {
							_requestInsertContactList.splice(i, 1);
							break;
						}
					}
				}
			}

			if ((_requestInsertContactList.length === 0) &&
				(_requestUpdateContactList.length === 0) &&
				(_requestDeleteContactList.length === 0)) {

				$rootScope.$broadcast('UpdateStudentContactInfo', _studentId, _contacts);

				hideDialogBox();
			}
		} else {
			onErrorInsertStudentContactInfo(data, status, headers, config);
		}
	};

	var onErrorInsertStudentContactInfo = function(data, status, headers, config) {
		$scope['isOnUpdateEdittedData'] = false;
		console.log('onErrorInsertStudentContactInfo');
	};

	var onSuccessUpdateStudentContactInfo = function(data, status, headers, config) {
		var isSuccess = data.d;
		if (isSuccess === true) {
			var updatedContact = config.data.studentContact;
			if (updatedContact !== null) {
				if (updatedContact.Type === Enum.ContactType.Phone) {
					for(var i = _contacts.phones.length - 1; i >= 0; i--) {
						var phone = _contacts.phones[i];

						if (phone.id === updatedContact.Id) {
							phone.label = updatedContact.Label;
							phone.value = updatedContact.Content;
							phone.status = updatedContact.Status;
							phone.isPrimary = updatedContact.IsPrimary;
							break;
						}
					}

					for(var i = _requestUpdateContactList.length - 1; i >= 0; i--) {
						var phone = _requestUpdateContactList[i];

						if (phone.id === updatedContact.Id) {
							_requestUpdateContactList.splice(i, 1);
							break;
						}
					}
				} else if (updatedContact.Type === Enum.ContactType.Email) {
					for(var i = _contacts.emails.length - 1; i >= 0; i--) {
						var email = _contacts.emails[i];

						if (email.id === updatedContact.Id) {
							email.label = updatedContact.Label;
							email.value = updatedContact.Content;
							email.status = updatedContact.Status;
							email.isPrimary = updatedContact.IsPrimary;
							break;
						}
					}

					for(var i = _requestUpdateContactList.length - 1; i >= 0; i--) {
						var email = _requestUpdateContactList[i];

						if (email.id === updatedContact.Id) {
							_requestUpdateContactList.splice(i, 1);
							break;
						}
					}
				}
			} 

			if ((_requestInsertContactList.length === 0) &&
				(_requestUpdateContactList.length === 0) &&
				(_requestDeleteContactList.length === 0)) {

				$rootScope.$broadcast('UpdateStudentContactInfo', _studentId, _contacts);

				hideDialogBox();
			}
		} else {
			onErrorUpdateStudentContactInfo(data, status, headers, config);
		}
	};

	var onErrorUpdateStudentContactInfo = function (data, status, headers, config) {
		$scope['isOnUpdateEdittedData'] = false;
		console.log('onErrorUpdateStudentContactInfo');
	};    
};