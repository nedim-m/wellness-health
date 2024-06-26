import 'dart:convert';

import 'package:desktop/models/shift.dart';
import 'package:desktop/providers/shift_provider.dart';
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
  final ShiftProvider shiftProvider = ShiftProvider();
  TextEditingController firstName = TextEditingController();
  TextEditingController lastName = TextEditingController();
  TextEditingController email = TextEditingController();
  TextEditingController userName = TextEditingController();
  TextEditingController phone = TextEditingController();
  TextEditingController password = TextEditingController();
  TextEditingController confirmPassword = TextEditingController();
  SearchResult<Role> myData = SearchResult<Role>();
  SearchResult<Shift> myDataShift = SearchResult<Shift>();
  Role? selectedRole;
  List<Role> allRoles = [];

  Shift? selectedShift;
  List<Shift> allShifts = [];
  File? selectedPhoto;
  final _formKey = GlobalKey<FormState>();
  final _validation = ValidationRules();
  String? _base64Image;
  String? _imageValidationError;
  bool? selectedStatus;

  @override
  void initState() {
    fetchData(); // Prvo dohvatimo podatke

    super.initState();
  }

  Future<void> fetchData() async {
    myData = await roleProvider.get();
    myDataShift = await shiftProvider.get();
    setState(() {
      allRoles = myData.result;
      allShifts = myDataShift.result;
    });

    if (widget.edit == true && widget.data != null) {
      firstName = TextEditingController(text: widget.data!.firstName);
      lastName = TextEditingController(text: widget.data!.lastName);
      email = TextEditingController(text: widget.data!.email);
      userName = TextEditingController(text: widget.data!.userName);
      phone = TextEditingController(text: widget.data!.phone);
      _base64Image = widget.data!.picture;
      selectedStatus = widget.data!.status;
      selectedRole =
          allRoles.firstWhere((role) => role.id == widget.data!.roleId);
      selectedShift =
          allShifts.firstWhere((shift) => shift.id == widget.data!.shiftId);
    }
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

  bool validateForm() {
    bool isValid = _formKey.currentState!.validate();

    if (selectedPhoto == null &&
        (_base64Image == null || _base64Image!.isEmpty)) {
      setState(() {
        _imageValidationError = 'Molimo odaberite fotografiju.';
        isValid = false;
      });
    }

    return isValid;
  }

  void showAddAlert(bool response) {
    String message = response
        ? 'Uspješno izmjenjeno'
        : 'Neuspješna akcija, korisnik sa ovim korisničkim imenom ili email-om već postoji';

    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          backgroundColor: Colors.white,
          title: response ? const Text('Uspješno') : const Text('Neuspješno'),
          content: Text(message),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: const Text('OK'),
            ),
          ],
        );
      },
    );
  }

  void _saveChanges() async {
    final provider = Provider.of<UserProvider>(context, listen: false);
    try {
      if (validateForm()) {
        if (widget.edit == true && widget.data != null) {
          await provider.updateWorker(
            widget.data!.id,
            firstName.text,
            lastName.text,
            email.text,
            userName.text,
            phone.text,
            selectedRole!.id,
            _base64Image ?? widget.data!.picture,
            selectedStatus!,
            selectedShift!.id,
          );
        } else {
          await provider.addWorker(
            firstName.text,
            lastName.text,
            email.text,
            userName.text,
            phone.text,
            selectedRole!.id,
            _base64Image ?? "N/A",
            selectedStatus!,
            selectedShift!.id,
          );
        }

        widget.refreshCallback();
        // ignore: use_build_context_synchronously
        Navigator.of(context).pop();
      }
    } catch (e) {
      showAddAlert(false);
    }
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      backgroundColor: Colors.white,
      title: widget.edit
          ? const Text("Ažuriraj zaposlenika")
          : const Text("Dodaj zaposlenika"),
      content: SingleChildScrollView(
        child: Form(
          key: _formKey,
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              GestureDetector(
                onTap: _selectPhoto,
                child: Column(
                  children: [
                    Container(
                      width: 100,
                      height: 100,
                      decoration: BoxDecoration(
                        color: Colors.grey[200],
                        border: Border.all(color: Colors.grey),
                      ),
                      child: Stack(
                        alignment: Alignment.center,
                        children: [
                          if (selectedPhoto != null)
                            Image.file(selectedPhoto!, fit: BoxFit.cover),
                          if (_base64Image != null && _base64Image!.isNotEmpty)
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
              TextFormField(
                controller: firstName,
                decoration: const InputDecoration(labelText: "Ime"),
                validator: (value) => _validation.validateTextInput(
                    value, 'Molim Vas unesite Vaše ime.'),
              ),
              TextFormField(
                controller: lastName,
                decoration: const InputDecoration(labelText: "Prezime"),
                validator: (value) => _validation.validateTextInput(
                    value, 'Molim Vas unesite Vaše prezime.'),
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
                    value, 'Molim Vas unesite Vaše korisničko ime'),
              ),
              TextFormField(
                controller: phone,
                decoration: const InputDecoration(labelText: "Telefon"),
                keyboardType: TextInputType.phone,
                validator: _validation.validatePhone,
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
                hint: const Text("Izaberite poziciju"),
                validator: _validation.validateDropdown,
              ),
              DropdownButtonFormField<Shift>(
                value: selectedShift,
                onChanged: (newValue) {
                  setState(() {
                    selectedShift = newValue!;
                  });
                },
                items: allShifts.map<DropdownMenuItem<Shift>>((Shift shift) {
                  return DropdownMenuItem<Shift>(
                    value: shift,
                    child: Text(shift.name),
                  );
                }).toList(),
                hint: const Text("Izaberite smjenu"),
                validator: _validation.validateDropdown,
              ),
              DropdownButtonFormField<bool>(
                value: selectedStatus,
                onChanged: (newValue) {
                  setState(() {
                    selectedStatus = newValue!;
                  });
                },
                items: const [
                  DropdownMenuItem<bool>(
                    value: true,
                    child: Text('Aktivan'),
                  ),
                  DropdownMenuItem<bool>(
                    value: false,
                    child: Text('Neaktivan'),
                  ),
                ],
                decoration: const InputDecoration(labelText: 'Status'),
                validator: _validation.validateDropdown,
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
