import 'package:desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/user.dart';

class WorkerEditPopUpWidget extends StatefulWidget {
  const WorkerEditPopUpWidget({
    Key? key,
    this.data,
    required this.edit,
  }) : super(key: key);

  final User? data;
  final bool edit;

  @override
  State<WorkerEditPopUpWidget> createState() => _WorkerEditPopUpWidgetState();
}

class _WorkerEditPopUpWidgetState extends State<WorkerEditPopUpWidget> {
  TextEditingController firstName = TextEditingController();
  TextEditingController lastName = TextEditingController();
  TextEditingController email = TextEditingController();
  TextEditingController userName = TextEditingController();
  TextEditingController phone = TextEditingController();
  TextEditingController password = TextEditingController();

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
    password.dispose();
    super.dispose();
  }

  void _saveChanges() async {
    final provider = Provider.of<UserProvider>(context, listen: false);
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
      provider.addWorker(
        firstName.text,
        lastName.text,
        email.text,
        userName.text,
        phone.text,
        password.text
      );
    }

    Navigator.of(context).pop();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: widget.edit ? const Text("Edit Worker") : const Text("Add Worker"),
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
          TextField(
            controller: password,
            decoration: const InputDecoration(labelText: "Password"),
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
