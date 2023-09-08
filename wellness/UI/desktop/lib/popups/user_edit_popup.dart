import 'package:desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/user.dart';

class UserEditPopUpWidget extends StatefulWidget {
  const UserEditPopUpWidget({
    Key? key,
    required this.data,
  }) : super(key: key);

  final User data;

  @override
  State<UserEditPopUpWidget> createState() => _UserEditPopUpWidgetState();
}

class _UserEditPopUpWidgetState extends State<UserEditPopUpWidget> {
  late TextEditingController firstName;
  late TextEditingController lastName;
  late TextEditingController email;
  late TextEditingController userName;
  late TextEditingController phone;

  @override
  void initState() {
    firstName = TextEditingController(text: widget.data.firstName);
    lastName = TextEditingController(text: widget.data.lastName);
    email = TextEditingController(text: widget.data.email);
    userName = TextEditingController(text: widget.data.userName);
    phone = TextEditingController(text: widget.data.phone);

    super.initState();
  }

  @override
  void dispose() {
    firstName.dispose();
    lastName.dispose();
    email.dispose();
    userName.dispose();
    phone.dispose();
    super.dispose();
  }

  void _saveChanges() async {
    final provider = Provider.of<UserProvider>(context, listen: false);
    provider.updateUser(
      widget.data.id,
      firstName.text,
      lastName.text,
      email.text,
      userName.text,
      phone.text,
    );

    Navigator.of(context).pop();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text("Edit User"),
      content: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          TextField(
            controller: firstName,
            decoration: const InputDecoration(labelText: "First Name"),
          ),
          TextField(
            controller: lastName,
            decoration: const InputDecoration(labelText: "Last Name"),
          ),
          TextField(
            controller: email,
            decoration: const InputDecoration(labelText: "Email"),
            keyboardType: TextInputType.emailAddress,
          ),
          TextField(
            controller: userName,
            decoration: const InputDecoration(labelText: "Username"),
          ),
          TextField(
            controller: phone,
            decoration: const InputDecoration(labelText: "Phone"),
            keyboardType: TextInputType.phone,
          ),
        ],
      ),
      actions: [
        TextButton(
          onPressed: _saveChanges,
          child: const Text("Save"),
        ),
        TextButton(
          onPressed: () {
            Navigator.of(context).pop();
          },
          child: const Text("Cancel"),
        ),
      ],
    );
  }
}
