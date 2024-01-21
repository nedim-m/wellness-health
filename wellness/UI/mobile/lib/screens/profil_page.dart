import 'package:flutter/material.dart';
import 'package:mobile/models/user.dart';
import 'package:mobile/providers/user_provider.dart';

import 'package:mobile/widgets/app_bar.dart';

class ProfilPageView extends StatefulWidget {
  const ProfilPageView({super.key});

  @override
  State<ProfilPageView> createState() => _ProfilPageViewState();
}

class _ProfilPageViewState extends State<ProfilPageView> {
  TextEditingController _firstNameController = TextEditingController();
  TextEditingController _lastNameController = TextEditingController();
  TextEditingController _emailController = TextEditingController();
  TextEditingController _userNameController = TextEditingController();
  TextEditingController _phoneController = TextEditingController();
  TextEditingController _passwordController = TextEditingController();
  TextEditingController _confirmPasswordController = TextEditingController();
  final UserProvider _userProvider = UserProvider();

  @override
  void initState() {
    super.initState();
    _loadUserData();
  }

  Future<void> _loadUserData() async {
    try {
      User userData = await _userProvider.getById();

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
    await _userProvider.updateUser(
        _firstNameController.text,
        _lastNameController.text,
        _emailController.text,
        _userNameController.text,
        _passwordController.text,
        _confirmPasswordController.text,
        _phoneController.text);
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
                  'Izmjena profila',
                  style: TextStyle(
                    fontSize: 24,
                    fontWeight: FontWeight.bold,
                    color: Colors.blue,
                  ),
                ),
              ),
              const SizedBox(height: 16),
              TextField(
                controller: _firstNameController,
                decoration: const InputDecoration(labelText: 'First Name'),
              ),
              TextField(
                controller: _lastNameController,
                decoration: const InputDecoration(labelText: 'Last Name'),
              ),
              TextField(
                controller: _emailController,
                decoration: const InputDecoration(labelText: 'Email'),
              ),
              TextField(
                controller: _userNameController,
                decoration: const InputDecoration(labelText: 'Username'),
              ),
              TextField(
                controller: _passwordController,
                obscureText: true,
                decoration: const InputDecoration(labelText: 'Password'),
              ),
              TextField(
                controller: _confirmPasswordController,
                obscureText: true,
                decoration:
                    const InputDecoration(labelText: 'Confirm Password'),
              ),
              TextField(
                controller: _phoneController,
                decoration: const InputDecoration(labelText: 'Phone'),
              ),
              const SizedBox(height: 20),
              ElevatedButton(
                onPressed: _saveChanges,
                child: const Text('Update Profile'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
