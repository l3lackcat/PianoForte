'use strict';

goog.provide('PianoForte.Utilities.FormatManager');

PianoForte.Utilities.FormatManager = function () {
    return {
        toDisplayedPhoneNumber: function (input) {
            var displayedPhoneNumber = false;

            if (phoneNumber != "") {
                string part1;
                string part2;
                string part3;

                int phoneNumberLength = phoneNumber.Length;
                if (phoneNumberLength == 9)
                {
                    if (phoneNumber.Substring(0, 2) == "02")
                    {
                        part1 = phoneNumber.Substring(0, 2);
                        part2 = phoneNumber.Substring(2, 3);
                        part3 = phoneNumber.Substring(5, phoneNumberLength - 5);
                    }
                    else
                    {
                        part1 = phoneNumber.Substring(0, 3);
                        part2 = phoneNumber.Substring(3, 3);
                        part3 = phoneNumber.Substring(6, phoneNumberLength - 6);
                    }

                    displayPhoneNumber = part1 + "-" + part2 + "-" + part3;
                }
                else if (phoneNumberLength == 10)
                {
                    part1 = phoneNumber.Substring(0, 3);
                    part2 = phoneNumber.Substring(3, 3);
                    part3 = phoneNumber.Substring(6, phoneNumberLength - 6);

                    displayPhoneNumber = part1 + "-" + part2 + "-" + part3;
                }
            }

            return displayedPhoneNumber;
        }
    };
};