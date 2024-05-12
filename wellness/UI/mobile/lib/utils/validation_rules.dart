class ValidationRules {
  String? validateTextInput(String? textInput, String errorMessage) {
    if (textInput == null || textInput.isEmpty) {
      return errorMessage;
    }
    if (textInput.contains(RegExp(r'[0-9]'))) {
      return 'Unos ne može sadržavati brojeve.';
    }
    return null;
  }

  String? validateEmail(String? email) {
    if (email == null || email.isEmpty) {
      return 'Molim Vas unesite email.';
    }
    if (!isValidEmail(email)) {
      return 'Nevažeća email adresa.';
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
      return 'Molim Vas unesite broj telefona.';
    }
    if (!RegExp(r'^06\d{7,8}$').hasMatch(phone)) {
      return 'Unesite 9 ili 10 cifara počevši od 06.';
    }
    return null;
  }

  String? validatePassword(String? password) {
    if (password == null || password.isEmpty) {
      return 'Unesite lozinku.';
    }
    if (password.length < 8) {
      return 'Lozinka mora imati najmanje 8 znakova.';
    }
    if (!RegExp(r'^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+])')
        .hasMatch(password)) {
      return 'Lozinka mora sadržavati najmanje jedno veliko slovo, broj i poseban znak.';
    }
    return null;
  }

  String? validateConfirmPassword(String? password, String? confirmpassword) {
    if (confirmpassword == null || confirmpassword.isEmpty) {
      return 'Unesite lozinku.';
    }
    if (confirmpassword.length < 8) {
      return 'Lozinka mora imati najmanje 8 znakova.';
    }
    if (!RegExp(r'^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+])')
        .hasMatch(confirmpassword)) {
      return 'Lozinka mora sadržavati najmanje jedno veliko slovo, broj i poseban znak.';
    }

    if (confirmpassword != password) {
      return "Potvrda lozinke mora biti identična loziniki.";
    }

    return null;
  }

  String? validateDropdown(dynamic value) {
    if (value == null) {
      return 'Molimo odaberite iz padajućeg menija.';
    }
    return null;
  }

  String? validatePrice(String? price) {
    if (price == null || price.isEmpty) {
      return 'Molimo unesite cijenu.';
    }

    final RegExp priceRegex = RegExp(r'^\d+(\.\d{1,2})?$');

    if (!priceRegex.hasMatch(price)) {
      return 'Nevažeći format cijene. Unesite ispravnu cijenu (npr. 10,99).';
    }

    return null;
  }

  String? validateNumberInput(String? userInput, String errorMessage) {
    if (userInput == null || userInput.isEmpty) {
      return errorMessage;
    }

    final RegExp numericRegex = RegExp(r'^[0-9]+$');

    if (!numericRegex.hasMatch(userInput)) {
      return 'Unos mora sadržavati samo brojeve.';
    }

    return null;
  }
}
