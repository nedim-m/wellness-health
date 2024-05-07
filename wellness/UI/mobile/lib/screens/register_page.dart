import 'package:flutter/material.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/screens/login_page.dart';
import 'package:mobile/utils/app_styles.dart';
import 'package:mobile/utils/validation_rules.dart';

class RegistrationPageView extends StatefulWidget {
  const RegistrationPageView({Key? key}) : super(key: key);

  @override
  State<RegistrationPageView> createState() => _RegistrationPageViewState();
}

class _RegistrationPageViewState extends State<RegistrationPageView> {
  final TextEditingController _firstNameController = TextEditingController();
  final TextEditingController _lastNameController = TextEditingController();
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _userNameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _confirmPasswordController =
      TextEditingController();
  final TextEditingController _phoneController = TextEditingController();
  final _validation = ValidationRules();

  final UserProvider _userProvider = UserProvider();

  Map<String, String?> _errorMessages = {};

  void _saveChanges() async {
    setState(() {
      _errorMessages = {
        'firstName': _validation.validateTextInput(
            _firstNameController.text, 'Unesite Vaše ime.'),
        'lastName': _validation.validateTextInput(
            _lastNameController.text, 'Unesite Vaše prezime.'),
        'email': _validation.validateEmail(_emailController.text),
        'userName': _validation.validateTextInput(
            _userNameController.text, 'Unesite Vaše korisničko ime'),
        'password': _validation.validatePassword(_passwordController.text),
        'confirmPassword': _validation.validateConfirmPassword(
            _passwordController.text, _confirmPasswordController.text),
        'phone': _validation.validatePhone(_phoneController.text),
      };
    });

    if (_errorMessages.values.every((element) => element == null)) {
      try {
        await _userProvider.register(
          _firstNameController.text,
          _lastNameController.text,
          _emailController.text,
          _userNameController.text,
          _passwordController.text,
          _confirmPasswordController.text,
          _phoneController.text,
        );

        _showRegistrationAlert(true);
      } catch (error) {
        _showRegistrationAlert(false);
      }
    }
  }

  void _showRegistrationAlert(bool response) {
    String message = 'Nepoznata greška';
    bool isSuccess = false;

    if (response) {
      isSuccess = true;
      message = 'Uspješna Registracija';
    } else {
      message =
          'Greška prilikom registracije, korisnik sa tim korisničkim imenom i/ili postoji.';
    }

    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: isSuccess ? const Text('Uspješno') : const Text('Greška'),
          content: Text(message),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();

                if (isSuccess) {
                  Navigator.of(context).pushReplacement(
                    MaterialPageRoute(
                      builder: (context) => const LoginPageView(),
                    ),
                  );
                }
              },
              child: const Text('OK'),
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Styles.bgColor,
      appBar: AppBar(
        title: const Text('Registracija'),
      ),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              _buildTextField(
                _firstNameController,
                'Ime',
                errorText: _errorMessages['firstName'],
              ),
              const SizedBox(height: 8.0),
              _buildTextField(
                _lastNameController,
                'Prezime',
                errorText: _errorMessages['lastName'],
              ),
              const SizedBox(height: 8.0),
              _buildTextField(
                _emailController,
                'Email',
                errorText: _errorMessages['email'],
              ),
              const SizedBox(height: 8.0),
              _buildTextField(
                _userNameController,
                'Korisničko ime',
                errorText: _errorMessages['userName'],
              ),
              const SizedBox(height: 8.0),
              _buildTextField(
                _passwordController,
                'Lozinka',
                isObscure: true,
                errorText: _errorMessages['password'],
              ),
              const SizedBox(height: 8.0),
              _buildTextField(
                _confirmPasswordController,
                'Potvrda lozinke',
                isObscure: true,
                errorText: _errorMessages['confirmPassword'],
              ),
              const SizedBox(height: 8.0),
              _buildTextField(
                _phoneController,
                'Telefon',
                errorText: _errorMessages['phone'],
              ),
              const SizedBox(height: 16.0),
              ElevatedButton(
                onPressed: _saveChanges,
                child: const Text('Registruj se'),
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildTextField(
    TextEditingController controller,
    String label, {
    bool isObscure = false,
    String? errorText,
  }) {
    return TextField(
      controller: controller,
      obscureText: isObscure,
      decoration: InputDecoration(
        labelText: label,
        errorText: errorText,
        errorStyle: const TextStyle(color: Colors.red),
      ),
    );
  }
}
