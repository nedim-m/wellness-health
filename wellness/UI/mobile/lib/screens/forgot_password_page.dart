import 'package:flutter/material.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/screens/login_page.dart';
import 'package:mobile/utils/validation_rules.dart';

class ForgotPageView extends StatefulWidget {
  const ForgotPageView({super.key});

  @override
  State<ForgotPageView> createState() => _ForgotPageViewState();
}

class _ForgotPageViewState extends State<ForgotPageView> {
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _userNameController = TextEditingController();
  final UserProvider _userProvider = UserProvider();
  final _validation = ValidationRules();

  Map<String, String?> _errorMessages = {};

  void _saveChanges() async {
    setState(() {
      _errorMessages = {
        'email': _validation.validateEmail(_emailController.text),
        'userName': _validation.validateTextInput(
          _userNameController.text,
          'Please enter your username.',
        ),
      };
    });

    if (_errorMessages.values.every((element) => element == null)) {
      try {
        await _userProvider.forgotPassword(
            _userNameController.text, _emailController.text);
        _showRegistrationAlert(true);
      } catch (error) {
        print("Caught an error: $error");
        _showRegistrationAlert(false);
      }
    }
  }

  void _showRegistrationAlert(bool response) {
    String message = 'Unknown error';
    bool isSuccess = false;

    if (response) {
      isSuccess = true;
      message = 'Password changed successfuly';
    } else {
      message =
          "Password change failed, User with that Username or Mail already doesn't exists";
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
        title: const Text('Forgot Password Page'),
      ),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              TextField(
                controller: _emailController,
                decoration: const InputDecoration(
                  labelText: 'Email',
                  hintText: 'Enter your email',
                ),
              ),
              if (_errorMessages['email'] != null)
                Padding(
                  padding: const EdgeInsets.only(top: 8.0),
                  child: Text(
                    _errorMessages['email']!,
                    style: const TextStyle(color: Colors.red),
                  ),
                ),
              const SizedBox(height: 16.0),
              TextField(
                controller: _userNameController,
                decoration: const InputDecoration(
                  labelText: 'Username',
                  hintText: 'Enter your username',
                ),
              ),
              if (_errorMessages['userName'] != null)
                Padding(
                  padding: const EdgeInsets.only(top: 8.0),
                  child: Text(
                    _errorMessages['userName']!,
                    style: const TextStyle(color: Colors.red),
                  ),
                ),
              const SizedBox(height: 32.0),
              ElevatedButton(
                onPressed: _saveChanges,
                child: const Text('Send Request'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
