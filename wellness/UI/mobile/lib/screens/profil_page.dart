// ignore_for_file: avoid_print

import 'package:flutter/material.dart';
import 'package:mobile/models/user.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/screens/login_page.dart';
import 'package:mobile/widgets/app_bar.dart';
import 'package:mobile/utils/validation_rules.dart';

class ProfilPageView extends StatefulWidget {
  const ProfilPageView({Key? key}) : super(key: key);

  @override
  State<ProfilPageView> createState() => _ProfilPageViewState();
}

class _ProfilPageViewState extends State<ProfilPageView> {
  TextEditingController _firstNameController = TextEditingController();
  TextEditingController _lastNameController = TextEditingController();
  TextEditingController _emailController = TextEditingController();
  TextEditingController _userNameController = TextEditingController();
  TextEditingController _phoneController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _confirmPasswordController =
      TextEditingController();
  final UserProvider _userProvider = UserProvider();
  final ValidationRules _validation = ValidationRules();
  late User userData;

  Map<String, String?> _errorMessages = {};

  @override
  void initState() {
    super.initState();
    _loadUserData();
  }

  Future<void> _loadUserData() async {
    try {
      userData = await _userProvider.getById();

      setState(() {
        _firstNameController =
            TextEditingController(text: userData.firstName.toString());
        _lastNameController =
            TextEditingController(text: userData.lastName.toString());
        _emailController =
            TextEditingController(text: userData.email.toString());
        _userNameController =
            TextEditingController(text: userData.userName.toString());
        _phoneController =
            TextEditingController(text: userData.phone.toString());
      });
    } catch (error) {
      print("Error loading user data: $error");
    }
  }

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
        await _userProvider.updateUser(
          _firstNameController.text,
          _lastNameController.text,
          _emailController.text,
          _userNameController.text,
          _passwordController.text,
          _confirmPasswordController.text,
          _phoneController.text,
          userData.status ?? false,
        );

        _showSuccessDialog();
      } catch (error) {
        print("Error updating user data: $error");
        _showErrorDialog();
      }
    }
  }

  void _showSuccessDialog() {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: const Text("Uspješno"),
          content: const Text(
              "Profil uspješno ažuriran! Molimo Vas ulogujte se ponovo."),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
                Navigator.pushReplacement(
                  context,
                  MaterialPageRoute(
                      builder: (context) => const LoginPageView()),
                );
              },
              child: const Text("OK"),
            ),
          ],
        );
      },
    );
  }

  void _showErrorDialog() {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: const Text("Greška"),
          content: const Text("Desila se greška. Molimo Vas pokušajte ponovo."),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: const Text("OK"),
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const AppBarWidget(),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              const SizedBox(height: 20),
              const Center(
                child: Text(
                  'Ažuriranje profila',
                  style: TextStyle(
                    fontSize: 24,
                    fontWeight: FontWeight.bold,
                    color: Colors.blue,
                  ),
                ),
              ),
              const SizedBox(height: 16),
              _buildTextField(
                _firstNameController,
                'Ime',
                errorText: _errorMessages['firstName'],
              ),
              _buildTextField(
                _lastNameController,
                'Prezime',
                errorText: _errorMessages['lastName'],
              ),
              _buildTextField(
                _emailController,
                'Email',
                errorText: _errorMessages['email'],
              ),
              _buildTextField(
                _userNameController,
                'Korisničko ime',
                errorText: _errorMessages['userName'],
              ),
              _buildTextField(
                _passwordController,
                'Lozinka',
                isObscure: true,
                errorText: _errorMessages['password'],
              ),
              _buildTextField(
                _confirmPasswordController,
                'Potvrdite lozinku',
                isObscure: true,
                errorText: _errorMessages['confirmPassword'],
              ),
              _buildTextField(
                _phoneController,
                'Telefon',
                errorText: _errorMessages['phone'],
              ),
              const SizedBox(height: 20),
              ElevatedButton(
                onPressed: _saveChanges,
                child: const Text('Ažuriraj profil'),
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
