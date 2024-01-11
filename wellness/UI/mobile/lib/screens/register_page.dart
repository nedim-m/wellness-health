import 'package:flutter/material.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/screens/login_page.dart';

class RegistrationPageView extends StatefulWidget {
  const RegistrationPageView({Key? key});

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

  final UserProvider _userProvider = UserProvider();
  bool _passwordsMatch = true;

  void _saveChanges() async {
    if (_passwordController.text == _confirmPasswordController.text) {
      try {
        dynamic response = await _userProvider.register(
          _firstNameController.text,
          _lastNameController.text,
          _emailController.text,
          _userNameController.text,
          _passwordController.text,
          _confirmPasswordController.text,
          _phoneController.text,
        );

       
        _showRegistrationAlert(response);
      } catch (error) {
       
        print("Error during registration: $error");
      }
    } else {
    
      setState(() {
        _passwordsMatch = false;
      });
    }
  }

  void _showRegistrationAlert(dynamic response) {
    String message = 'Unknown error';
    bool isSuccess = false;

    if (response != null) {
   
      isSuccess = true;
      message = 'Registration Successful';
    } else {
      message = 'Registration Failed';
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
                      builder: (context) =>
                          const LoginPageView(), 
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
              _buildTextField(_firstNameController, 'First Name'),
              const SizedBox(height: 8.0),
              _buildTextField(_lastNameController, 'Last Name'),
              const SizedBox(height: 8.0),
              _buildTextField(_emailController, 'Email'),
              const SizedBox(height: 8.0),
              _buildTextField(_userNameController, 'Username'),
              const SizedBox(height: 8.0),
              _buildTextField(_passwordController, 'Password', isObscure: true),
              const SizedBox(height: 8.0),
              _buildTextField(
                _confirmPasswordController,
                'Confirm Password',
                isObscure: true,
                errorText: !_passwordsMatch ? 'Passwords do not match' : null,
              ),
              const SizedBox(height: 8.0),
              _buildTextField(_phoneController, 'Phone'),
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

  Widget _buildTextField(TextEditingController controller, String label,
      {bool isObscure = false, String? errorText}) {
    return TextField(
      controller: controller,
      obscureText: isObscure,
      decoration: InputDecoration(
        labelText: label,
        errorText: errorText,
      ),
    );
  }
}
