import 'package:desktop/utils/token_store.dart';
import 'package:flutter/material.dart';

class UserPageView extends StatefulWidget {
  const UserPageView({super.key});

  @override
  State<UserPageView> createState() => _UserPageViewState();
}

class _UserPageViewState extends State<UserPageView> {
  String? _token;

  @override
  void initState() {
    _token = TokenManager.getToken();
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Text("Token: $_token"),
    );
  }
}
