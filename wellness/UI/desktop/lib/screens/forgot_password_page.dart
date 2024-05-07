// ignore_for_file: avoid_print

import 'package:desktop/providers/user_provider.dart';
import 'package:desktop/screens/login_page.dart';
import 'package:desktop/utils/validation_rules.dart';
import 'package:flutter/material.dart';

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
          'Molim Vas unesite korisničko ime.',
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
    String message = 'Greška!';
    bool isSuccess = false;

    if (response) {
      isSuccess = true;
      message = 'Lozinka uspješno promjenjena';
    } else {
      message =
          "Greška prilikom promjene loznike, zaposlenik sa tim korisničkim podacima ne postoji!";
    }

    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          backgroundColor: Colors.white,
          title: isSuccess ? const Text('Uspješno') : const Text('Neuspješno'),
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
      backgroundColor: Colors.blue[100],
      appBar: AppBar(
        title: const Text('Zaboravljena lozinka'),
      ),
      body: Center(
        child: Container(
          width: 400,
          padding: const EdgeInsets.all(16.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              TextField(
                controller: _emailController,
                decoration: const InputDecoration(
                  labelText: 'Email',
                  hintText: 'Unesite vašu email adresu',
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
                  labelText: 'Korisničko ime',
                  hintText: 'Unesite korisničko ime',
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
                child: const Text('Zahtjev za novu lozinku'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
