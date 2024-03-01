import 'dart:convert';
import 'dart:io';

import 'package:desktop/models/user.dart';
import 'package:desktop/providers/user_provider.dart';
import 'package:desktop/utils/validation_rules.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';

class EmployeeUpdateScreen extends StatefulWidget {
  const EmployeeUpdateScreen({
    Key? key,
  }) : super(key: key);

  @override
  State<EmployeeUpdateScreen> createState() => _EmployeeUpdateScreenState();
}

class _EmployeeUpdateScreenState extends State<EmployeeUpdateScreen> {
  TextEditingController firstName = TextEditingController();
  TextEditingController lastName = TextEditingController();
  TextEditingController email = TextEditingController();
  TextEditingController userName = TextEditingController();
  TextEditingController phone = TextEditingController();
  TextEditingController password = TextEditingController();
  TextEditingController confirmPassword = TextEditingController();

  File? selectedPhoto;

  final _validation = ValidationRules();
  String? _base64Image;
  String? _imageValidationError;
  late User loggedUserdata;
  final UserProvider _userProvider = UserProvider();

  Future<void> _selectPhoto() async {
    FilePickerResult? result = await FilePicker.platform.pickFiles(
      type: FileType.image,
    );

    setState(() {
      _imageValidationError = null;
    });

    if (result != null) {
      setState(() {
        selectedPhoto = File(result.files.single.path!);
        _base64Image = base64Encode(selectedPhoto!.readAsBytesSync());
      });
    } else {
      setState(() {
        _imageValidationError = 'Molimo odaberite fotografiju.';
      });
    }
  }

  /*Future<void> fetchData() async {
    loggedUserdata = await _userProvider.getById();

    firstName = TextEditingController(text: loggedUserdata.firstName);
    lastName = TextEditingController(text: loggedUserdata.lastName);
    email = TextEditingController(text: loggedUserdata.email);
    userName = TextEditingController(text: loggedUserdata.userName);
    phone = TextEditingController(text: loggedUserdata.phone);
    _base64Image = loggedUserdata.picture;
  }*/

  @override
  void initState() {
    //fetchData();

    super.initState();
  }

  void _saveChanges() {}

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Center(
          child: Container(
            width: 500,
            padding: const EdgeInsets.all(16.0),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                const Center(
                  child: Text(
                    "Ažuriraj profil",
                    style: TextStyle(
                      fontSize: 24,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                ),
                const SizedBox(
                  height: 30,
                ),
                GestureDetector(
                  onTap: _selectPhoto,
                  child: Column(
                    children: [
                      Container(
                        width: 200,
                        height: 200,
                        decoration: BoxDecoration(
                          color: Colors.grey[200],
                          border: Border.all(color: Colors.grey),
                        ),
                        child: Stack(
                          alignment: Alignment.center,
                          children: [
                            if (selectedPhoto != null)
                              Image.file(selectedPhoto!, fit: BoxFit.cover),
                            if (_base64Image != null &&
                                _base64Image!.isNotEmpty)
                              Image.memory(
                                base64.decode(_base64Image!),
                                fit: BoxFit.cover,
                              ),
                            if (selectedPhoto == null &&
                                (_base64Image == null || _base64Image!.isEmpty))
                              const Center(
                                child: Text(
                                  "Dodajte fotografiju",
                                  textAlign: TextAlign.center,
                                  style: TextStyle(
                                    color: Colors.grey,
                                  ),
                                ),
                              ),
                          ],
                        ),
                      ),
                      if (_imageValidationError != null)
                        Text(
                          _imageValidationError!,
                          style: const TextStyle(
                            color: Colors.red,
                          ),
                        ),
                    ],
                  ),
                ),
                const SizedBox(height: 16.0),
                TextFormField(
                  controller: firstName,
                  decoration: const InputDecoration(labelText: "Ime"),
                  validator: (value) =>
                      _validation.validateTextInput(value, 'Unesite Vaše ime.'),
                ),
                TextFormField(
                  controller: lastName,
                  decoration: const InputDecoration(labelText: "Prezime"),
                  validator: (value) => _validation.validateTextInput(
                      value, 'Unesite Vaše prezime.'),
                ),
                TextFormField(
                  controller: email,
                  decoration: const InputDecoration(labelText: "Email"),
                  keyboardType: TextInputType.emailAddress,
                  validator: _validation.validateEmail,
                ),
                TextFormField(
                  controller: userName,
                  decoration:
                      const InputDecoration(labelText: "Korisničko ime"),
                  validator: (value) => _validation.validateTextInput(
                      value, 'Unesite Vaše korisničko ime'),
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
                  decoration:
                      const InputDecoration(labelText: "Potvrda lozinke"),
                  obscureText: true,
                  validator: (value) =>
                      _validation.validateConfirmPassword(password.text, value),
                ),
                const SizedBox(height: 16.0),
                ElevatedButton(
                  onPressed: _saveChanges,
                  child: const Text('Spremi promjene'),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
