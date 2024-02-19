import 'package:desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

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
  TextEditingController password = TextEditingController();
  TextEditingController confirmPassword = TextEditingController();

  File? selectedPhoto;
  final _formKey = GlobalKey<FormState>();
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
      if (widget.edit == true && widget.data != null) {
        await provider.updateUser(
          widget.data!.id,
          firstName.text,
          lastName.text,
          email.text,
          userName.text,
          phone.text,
          password.text,
        );
      } else {
        await provider.addUser(
          firstName.text,
          lastName.text,
          email.text,
          userName.text,
          phone.text,
          password.text,
        );
      }

      widget.refreshCallback();
      // ignore: use_build_context_synchronously
      Navigator.of(context).pop();
    }
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: widget.edit
          ? const Text("Ažuriraj korisnika")
          : const Text("Dodaj korisnika"),
      content: SingleChildScrollView(
        child: Form(
          key: _formKey,
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              TextFormField(
                controller: firstName,
                decoration: const InputDecoration(labelText: "Ime"),
                validator: (value) => _validation.validateTextInput(
                    value, 'Molim Vas unesti Vaše ime.'),
              ),
              TextFormField(
                controller: lastName,
                decoration: const InputDecoration(labelText: "Prezime"),
                validator: (value) => _validation.validateTextInput(
                    value, 'Molim Vas unesti Vaše prezime.'),
              ),
              TextFormField(
                controller: email,
                decoration: const InputDecoration(labelText: "Email"),
                keyboardType: TextInputType.emailAddress,
                validator: _validation.validateEmail,
              ),
              TextFormField(
                controller: userName,
                decoration: const InputDecoration(labelText: "Korisničko ime"),
                validator: (value) => _validation.validateTextInput(
                    value, 'Molim Vas unesti Vaše korisničko ime'),
              ),
              TextFormField(
                controller: phone,
                decoration: const InputDecoration(labelText: "Telefon"),
                keyboardType: TextInputType.phone,
                validator: _validation.validatePhone,
              ),
              TextFormField(
                controller: password,
                decoration: const InputDecoration(labelText: "Lozinka"),
                obscureText: true,
                validator: _validation.validatePassword,
              ),
              TextFormField(
                controller: confirmPassword,
                decoration: const InputDecoration(labelText: "Potvrda lozinke"),
                obscureText: true,
                validator: (value) =>
                    _validation.validateConfirmPassword(password.text, value),
              ),
            ],
          ),
        ),
      ),
      actions: [
        TextButton(
          onPressed: _saveChanges,
          child: const Text("Spremi"),
        ),
        TextButton(
          onPressed: () {
            Navigator.of(context).pop();
          },
          child: const Text("Otkaži"),
        ),
      ],
    );
  }
}
