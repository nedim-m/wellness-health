import 'dart:convert';

import 'package:desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:file_picker/file_picker.dart';
import 'dart:io';

import '../models/role.dart';
import '../models/search_result.dart';
import '../models/user.dart';
import '../providers/role_provider.dart';
import '../utils/validation_rules.dart';

class WorkerEditPopUpWidget extends StatefulWidget {
  const WorkerEditPopUpWidget({
    Key? key,
    this.data,
    required this.edit,
    required this.refreshCallback,
  }) : super(key: key);

  final User? data;
  final bool edit;
  final Function() refreshCallback;

  @override
  State<WorkerEditPopUpWidget> createState() => _WorkerEditPopUpWidgetState();
}

class _WorkerEditPopUpWidgetState extends State<WorkerEditPopUpWidget> {
  final RoleProvider roleProvider = RoleProvider();
  TextEditingController firstName = TextEditingController();
  TextEditingController lastName = TextEditingController();
  TextEditingController email = TextEditingController();
  TextEditingController userName = TextEditingController();
  TextEditingController phone = TextEditingController();
  TextEditingController password = TextEditingController();
  SearchResult<Role> myData = SearchResult<Role>();
  Role? selectedRole;
  List<Role> allRoles = [];
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
    }
    fetchData();

    super.initState();
  }

  Future<void> fetchData() async {
    myData = await roleProvider.get();
    setState(() {
      allRoles = myData.result;
    });
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

  Future<void> _selectPhoto() async {
    FilePickerResult? result = await FilePicker.platform.pickFiles(
      type: FileType.image,
    );

    if (result != null) {
      setState(() {
        selectedPhoto = File(result.files.single.path!);
      });

      _base64Image = base64Encode(selectedPhoto!.readAsBytesSync());
    }
  }

  void _saveChanges() async {
    final provider = Provider.of<UserProvider>(context, listen: false);
    if (_formKey.currentState!.validate()) {
      if (widget.edit == true && widget.data != null) {
        await provider.updateWorker(
          widget.data!.id,
          firstName.text,
          lastName.text,
          email.text,
          userName.text,
          phone.text,
          password.text,
          selectedRole!.id,
          _base64Image!,
        );
      } else {
        await provider.addWorker(
          firstName.text,
          lastName.text,
          email.text,
          userName.text,
          phone.text,
          password.text,
          selectedRole!.id,
          _base64Image!,
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
      title: widget.edit ? const Text("Edit Worker") : const Text("Add Worker"),
      content: SingleChildScrollView(
        child: Form(
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
              TextFormField(
                controller: password,
                decoration: const InputDecoration(labelText: "Password"),
                keyboardType: TextInputType.visiblePassword,
                validator: _validation.validatePassword,
              ),
              DropdownButtonFormField<Role>(
                value: selectedRole,
                onChanged: (newValue) {
                  setState(() {
                    selectedRole = newValue!;
                  });
                },
                items: allRoles.map<DropdownMenuItem<Role>>((Role role) {
                  return DropdownMenuItem<Role>(
                    value: role,
                    child: Text(role.name),
                  );
                }).toList(),
                hint: const Text("Choose a Role"),
                validator: _validation.validateDropdown,
              ),
            ],
          ),
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
