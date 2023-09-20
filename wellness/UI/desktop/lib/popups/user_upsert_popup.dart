import 'package:desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/user.dart';
import '../utils/validation_rules.dart';

class UserEditPopUpWidget extends StatefulWidget {
  const UserEditPopUpWidget({
    Key? key,
    this.data,
    required this.edit,
  }) : super(key: key);

  final User? data;
  final bool edit;

  @override
  State<UserEditPopUpWidget> createState() => _UserEditPopUpWidgetState();
}

class _UserEditPopUpWidgetState extends State<UserEditPopUpWidget> {
  TextEditingController firstName = TextEditingController();
  TextEditingController lastName = TextEditingController();
  TextEditingController email = TextEditingController();
  TextEditingController userName = TextEditingController();
  TextEditingController phone = TextEditingController();

  final _formKey = GlobalKey<FormState>(); // Add a form key
  final _validation = ValidationRules();

  @override
  void initState() {
    if (widget.edit == true && widget.data != null) {
      firstName = TextEditingController(text: widget.data!.firstName);
      lastName = TextEditingController(text: widget.data!.lastName);
      email = TextEditingController(text: widget.data!.email);
      userName = TextEditingController(text: widget.data!.userName);
      phone = TextEditingController(text: widget.data!.phone);
    }

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
    if (_formKey.currentState!.validate()) {
      // Validate the form
      if (widget.edit == true && widget.data != null) {
        provider.updateUser(
          widget.data!.id,
          firstName.text,
          lastName.text,
          email.text,
          userName.text,
          phone.text,
        );
      } else {
        provider.addUser(
          firstName.text,
          lastName.text,
          email.text,
          userName.text,
          phone.text,
        );
      }

      Navigator.of(context).pop();
    }
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: widget.edit ? const Text("Edit User") : const Text("Add User"),
      content: Form(
        key: _formKey, // Assign the form key to the form
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            TextFormField(
              controller: firstName,
              decoration: const InputDecoration(labelText: "First Name"),
              validator: (value) => _validation.validateTextInput(
                  value, 'Please enter your First Name.'),
            ),
            TextFormField(
              controller: lastName,
              decoration: const InputDecoration(labelText: "Last Name"),
              validator: (value) => _validation.validateTextInput(
                  value, 'Please enter your Last Name.'),
            ),
            TextFormField(
              controller: email,
              decoration: const InputDecoration(labelText: "Email"),
              keyboardType: TextInputType.emailAddress,
              validator: _validation.validateEmail,
            ),
            TextFormField(
              controller: userName,
              decoration: const InputDecoration(labelText: "Username"),
              validator: (value) => _validation.validateTextInput(
                  value, 'Please enter your Username'),
            ),
            TextFormField(
              controller: phone,
              decoration: const InputDecoration(labelText: "Phone"),
              keyboardType: TextInputType.phone,
              validator: (value) => _validation.validatePhone(value),
            ),
          ],
        ),
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
