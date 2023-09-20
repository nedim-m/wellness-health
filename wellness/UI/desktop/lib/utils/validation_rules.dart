class ValidationRules {
  String? validateTextInput(String? textInput, String errorMessage) {
    if (textInput == null || textInput.isEmpty) {
      return errorMessage;
    }
    if (textInput.contains(RegExp(r'[0-9]'))) {
      return 'Input cannot contain numbers.';
    }
    return null;
  }

  String? validateEmail(String? email) {
    if (email == null || email.isEmpty) {
      return 'Please enter your email.';
    }
    if (!isValidEmail(email)) {
      return 'Invalid email address.';
    }
    return null;
  }

  bool isValidEmail(String? email) {
    if (email == null || email.isEmpty) {
      return false;
    }
    return RegExp(r'^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$')
        .hasMatch(email);
  }

  String? validatePhone(String? phone) {
    if (phone == null || phone.isEmpty) {
      return 'Please enter your phone number.';
    }
    if (!RegExp(r'^06\d{7,8}$').hasMatch(phone)) {
      return 'Please enter 9 or 10 digits starting with 06.';
    }
    return null;
  }
}
