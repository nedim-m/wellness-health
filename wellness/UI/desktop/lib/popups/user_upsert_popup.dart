import 'dart:convert';

import 'package:desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:file_picker/file_picker.dart';
import 'dart:io';

import '../models/user.dart';
import '../utils/validation_rules.dart';

class UserEditPopUpWidget extends StatefulWidget {
  const UserEditPopUpWidget({
    Key? key,
    this.data,
    required this.edit,
    required this.refreshCallback,
  }) : super(key: key);

  final User? data;
  final bool edit;
  final Function() refreshCallback;

  @override
  State<UserEditPopUpWidget> createState() => _UserEditPopUpWidgetState();
}

class _UserEditPopUpWidgetState extends State<UserEditPopUpWidget> {
  TextEditingController firstName = TextEditingController();
  TextEditingController lastName = TextEditingController();
  TextEditingController email = TextEditingController();
  TextEditingController userName = TextEditingController();
  TextEditingController phone = TextEditingController();

  File? selectedPhoto;
  final _formKey = GlobalKey<FormState>();
  final _validation = ValidationRules();
  String? _base64Image;

  @override
  void initState() {
    if (widget.edit == true && widget.data != null) {
      firstName = TextEditingController(text: widget.data!.firstName);
      lastName = TextEditingController(text: widget.data!.lastName);
      email = TextEditingController(text: widget.data!.email);
      userName = TextEditingController(text: widget.data!.userName);
      phone = TextEditingController(text: widget.data!.phone);
      _base64Image = widget.data!.picture;
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

  Future<void> _selectPhoto() async {
    FilePickerResult? result = await FilePicker.platform.pickFiles(
      type: FileType.image,
    );

    if (result != null) {
      setState(() {
        selectedPhoto = File(result.files.single.path!);
        _base64Image = base64Encode(selectedPhoto!.readAsBytesSync());
      });
    }
  }

  void _saveChanges() async {
    final provider = Provider.of<UserProvider>(context, listen: false);
    if (_formKey.currentState!.validate()) {
      if (widget.edit == true && widget.data != null) {
        await provider.updateUser(
          widget.data!.id,
          firstName.text,
          lastName.text,
          email.text,
          userName.text,
          phone.text,
          _base64Image ?? widget.data!.picture,
        );
      } else {
        await provider.addUser(
          firstName.text,
          lastName.text,
          email.text,
          userName.text,
          phone.text,
          _base64Image ?? "N/A",
        );
      }

      widget.refreshCallback();
      Navigator.of(context).pop();
    }
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: widget.edit ? const Text("Edit User") : const Text("Add User"),
      content: Form(
        key: _formKey,
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            GestureDetector(
              onTap: _selectPhoto,
              child: Container(
                width: 100,
                height: 100,
                decoration: BoxDecoration(
                  color: Colors.grey[200],
                  border: Border.all(color: Colors.grey),
                ),
                child: selectedPhoto != null
                    ? Image.file(selectedPhoto!, fit: BoxFit.cover)
                    : _base64Image != null && _base64Image!.isNotEmpty
                        ? Image.memory(
                            base64.decode(_base64Image!),
                            fit: BoxFit.cover,
                          )
                        : const Center(
                            child: Text(
                              "Tap to Add Photo",
                              textAlign: TextAlign.center,
                              style: TextStyle(
                                color: Colors.grey,
                              ),
                            ),
                          ),
              ),
            ),
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
              validator: _validation.validatePhone,
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
