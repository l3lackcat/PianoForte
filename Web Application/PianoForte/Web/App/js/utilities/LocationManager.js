'use strict';

goog.provide('PianoForte.Utilities.LocationManager');

PianoForte.Utilities.LocationManager = function (LocationDataModel) {
	return {
		getPostcodeList: function () {
			return LocationDataModel['PostcodeList'];
		},

		getProvinceList: function(postcode) {
			if (postcode !== undefined) {
				return LocationDataModel['PostcodeToProvinceDictionary'][postcode];
			} else {
				return LocationDataModel['ProvinceList'];
			}
		},

		getDistrictList: function(province) {
			if (province !== undefined) {
				return LocationDataModel['ProvinceToDistrictDictionary'][province];
			} else {
				return LocationDataModel['DistrictList'];
			}
		},

		getSubDistrictList: function(district) {
			if (district !== undefined) {
				return LocationDataModel['DistrictToSubDistrictDictionary'][district];
			} else {
				return LocationDataModel['SubDistrictList'];
			}
		}
	};
};