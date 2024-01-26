import 'package:flutter/material.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/screens/login_page.dart';
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
            _firstNameController.text, 'Please enter your first name.'),
        'lastName': _validation.validateTextInput(
            _lastNameController.text, 'Please enter your last name.'),
        'email': _validation.validateEmail(_emailController.text),
        'userName': _validation.validateTextInput(
            _userNameController.text, 'Please enter your username.'),
        'password': _validation.validatePassword(_passwordController.text),
        'confirmPassword':
            _passwordController.text == _confirmPasswordController.text
                ? null
                : 'Passwords do not match',
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
    String message = 'Unknown error';
    bool isSuccess = false;

    if (response) {
      isSuccess = true;
      message = 'Registration Successful';
    } else {
      message =
          'Registration failed, User with that Username or Mail already exists';
    }

    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: isSuccess ? const Text('Success') : const Text('Error'),
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
      appBar: AppBar(
        title: const Text('Registration Page'),
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
                'First Name',
                errorText: _errorMessages['firstName'],
              ),
              const SizedBox(height: 8.0),
              _buildTextField(
                _lastNameController,
                'Last Name',
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
                'Username',
                errorText: _errorMessages['userName'],
              ),
              const SizedBox(height: 8.0),
              _buildTextField(
                _passwordController,
                'Password',
                isObscure: true,
                errorText: _errorMessages['password'],
              ),
              const SizedBox(height: 8.0),
              _buildTextField(
                _confirmPasswordController,
                'Confirm Password',
                isObscure: true,
                errorText: _errorMessages['confirmPassword'],
              ),
              const SizedBox(height: 8.0),
              _buildTextField(
                _phoneController,
                'Phone',
                errorText: _errorMessages['phone'],
              ),
              const SizedBox(height: 16.0),
              ElevatedButton(
                onPressed: _saveChanges,
                child: const Text('Register'),
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
