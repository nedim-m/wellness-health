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

  String? validatePassword(String? password) {
    if (password == null || password.isEmpty) {
      return 'Please enter a password.';
    }
    if (password.length < 8) {
      return 'Password must be at least 8 characters long.';
    }
    if (!RegExp(r'^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+])')
        .hasMatch(password)) {
      return 'Password must contain at least one capital letter, one number, and one special character.';
    }
    return null;
  }

  String? validateDropdown(dynamic value) {
    if (value == null) {
      return 'Please select a from dropdown.';
    }
    return null;
  }

  String? validatePrice(String? price) {
    if (price == null || price.isEmpty) {
      return 'Please enter a price.';
    }

    final RegExp priceRegex = RegExp(r'^\d+(\.\d{1,2})?$');

    if (!priceRegex.hasMatch(price)) {
      return 'Invalid price format. Please enter a valid price (e.g., 10.99).';
    }

    return null;
  }
}
