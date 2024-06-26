import 'package:flutter/material.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/screens/forgot_password_page.dart';

import 'package:mobile/screens/home_page.dart';
import 'package:mobile/screens/register_page.dart';
import 'package:mobile/utils/app_styles.dart';
import 'package:mobile/utils/recommender_helper.dart';

import 'package:mobile/utils/user_store.dart';

class LoginPageView extends StatefulWidget {
  const LoginPageView({super.key});

  @override
  State<LoginPageView> createState() => _LoginPageViewState();
}

class _LoginPageViewState extends State<LoginPageView> {
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final UserProvider _userProvider = UserProvider();
  bool _loginFailed = false;
  final String _errorMessage = "Neispravano korisničko ime ili lozinka!";

  Future<void> _login() async {
    final String username = _usernameController.text;
    final String password = _passwordController.text;
    final response = await _userProvider.login(username, password);
    if (response) {
      setState(() {
        _usernameController.clear();
        _passwordController.clear();
      });
      _loginFailed = false;
      // ignore: use_build_context_synchronously
      Navigator.push(
        context,
        MaterialPageRoute(builder: (context) => const HomepageView()),
      );
      RecommendedHelper.removeRecommendation();
      UserManager.removeCredentials();
      UserManager.getFullNameAsync();
    } else {
      setState(() {
        _loginFailed = true;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    final double fontSize = MediaQuery.of(context).size.width * 0.05;

    return Scaffold(
      backgroundColor: Styles.bgColor,
      body: SingleChildScrollView(
        child: Center(
          child: Container(
            padding: const EdgeInsets.all(16.0),
            constraints: const BoxConstraints(maxWidth: 400),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: <Widget>[
                Icon(
                  Icons.spa,
                  size: 100.0,
                  color: Colors.green[300],
                ),
                const SizedBox(height: 16.0),
                const Text(
                  'Wellness center - Health',
                  textAlign: TextAlign.center,
                  style: TextStyle(
                    fontSize: 24.0,
                    fontWeight: FontWeight.bold,
                    color: Colors.black87,
                  ),
                ),
                const SizedBox(height: 32.0),
                Container(
                  decoration: BoxDecoration(
                    border: _loginFailed
                        ? Border.all(color: Colors.red)
                        : Border.all(color: Colors.grey),
                    borderRadius: BorderRadius.circular(8.0),
                  ),
                  child: TextField(
                    controller: _usernameController,
                    decoration: const InputDecoration(
                      labelText: 'Korisničko ime',
                      border: OutlineInputBorder(),
                    ),
                  ),
                ),
                const SizedBox(height: 16.0),
                Container(
                  decoration: BoxDecoration(
                    border: _loginFailed
                        ? Border.all(color: Colors.red)
                        : Border.all(color: Colors.grey),
                    borderRadius: BorderRadius.circular(8.0),
                  ),
                  child: TextField(
                    controller: _passwordController,
                    obscureText: true,
                    decoration: const InputDecoration(
                      labelText: 'Lozinka',
                      border: OutlineInputBorder(),
                    ),
                  ),
                ),
                if (_loginFailed)
                  Padding(
                    padding: const EdgeInsets.only(top: 8.0),
                    child: Text(
                      _errorMessage,
                      style: const TextStyle(color: Colors.red),
                    ),
                  ),
                const SizedBox(height: 24.0),
                ElevatedButton(
                  onPressed: _login,
                  style: ElevatedButton.styleFrom(),
                  child: Text(
                    'Ulogujte se',
                    style: TextStyle(
                      fontSize: fontSize,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                ),
                const SizedBox(height: 16.0),
                TextButton(
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => const ForgotPageView()),
                    );
                  },
                  child: const Text(
                    'Zaboravljena lozinka?',
                    style: TextStyle(
                      color: Colors.black87,
                    ),
                  ),
                ),
                TextButton(
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => const RegistrationPageView()),
                    );
                  },
                  child: const Text(
                    'Registracija',
                    style: TextStyle(
                      color: Colors.black87,
                    ),
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
