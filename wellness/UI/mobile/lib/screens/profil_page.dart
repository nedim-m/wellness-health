import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/widgets/app_bar.dart';

class ProfilPageView extends StatelessWidget {
  const ProfilPageView({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return const Scaffold(
      appBar: AppBarWidget(),
      body: SingleChildScrollView(
        child: Padding(
          padding: EdgeInsets.all(20.0),
          child: ProfilePage(), // Include the ProfilePage here
        ),
      ),
    );
  }
}

class ProfilePage extends StatefulWidget {
  const ProfilePage({super.key});

  @override
  _ProfilePageState createState() => _ProfilePageState();
}

class _ProfilePageState extends State<ProfilePage> {
  final TextEditingController _firstNameController = TextEditingController();
  final TextEditingController _lastNameController = TextEditingController();
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _userNameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _confirmPasswordController =
      TextEditingController();
  final TextEditingController _pictureController = TextEditingController();
  final TextEditingController _phoneController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.stretch,
      children: [
        Container(
          width: 120,
          height: 120,
          decoration: BoxDecoration(
            shape: BoxShape.circle,
            image: DecorationImage(
              fit: BoxFit.cover,
              image: NetworkImage(_pictureController.text),
            ),
          ),
        ),
        SizedBox(height: 20),
        TextField(
          controller: _pictureController,
          decoration: InputDecoration(labelText: 'Profile Picture URL'),
        ),
        TextField(
          controller: _firstNameController,
          decoration: InputDecoration(labelText: 'First Name'),
        ),
        TextField(
          controller: _lastNameController,
          decoration: InputDecoration(labelText: 'Last Name'),
        ),
        TextField(
          controller: _emailController,
          decoration: InputDecoration(labelText: 'Email'),
        ),
        TextField(
          controller: _userNameController,
          decoration: InputDecoration(labelText: 'Username'),
        ),
        TextField(
          controller: _passwordController,
          obscureText: true,
          decoration: InputDecoration(labelText: 'Password'),
        ),
        TextField(
          controller: _confirmPasswordController,
          obscureText: true,
          decoration: InputDecoration(labelText: 'Confirm Password'),
        ),
        TextField(
          controller: _phoneController,
          decoration: InputDecoration(labelText: 'Phone'),
        ),
        SizedBox(height: 20),
        ElevatedButton(
          onPressed: () {
            // Handle profile update here
            // You can access the entered values using _firstNameController.text, _lastNameController.text, etc.
          },
          child: Text('Update Profile'),
        ),
      ],
    );
  }
}
