import 'dart:convert';
import 'dart:io';

import 'package:desktop/models/treatment_type.dart';
import 'package:desktop/providers/category_provider.dart';
import 'package:desktop/providers/treatment_provider.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/category.dart';
import '../models/search_result.dart';
import '../models/treatment.dart';

import '../providers/treatment_type_provider.dart';
import '../utils/validation_rules.dart';

class TreatmenUpsertPopUpWidget extends StatefulWidget {
  const TreatmenUpsertPopUpWidget({
    Key? key,
    this.data,
    required this.edit,
    required this.refreshCallback,
  }) : super(key: key);

  final Treatment? data;
  final bool edit;
  final Function() refreshCallback;

  @override
  State<TreatmenUpsertPopUpWidget> createState() =>
      _TreatmenUpsertPopUpWidgetState();
}

class _TreatmenUpsertPopUpWidgetState extends State<TreatmenUpsertPopUpWidget> {
  TextEditingController description = TextEditingController();
  TextEditingController price = TextEditingController();
  TextEditingController duration = TextEditingController();
  TextEditingController name = TextEditingController();
  final TreatmentTypeProvider treatmentProvider = TreatmentTypeProvider();
  final CategoryProvider categoryProvider = CategoryProvider();

  SearchResult<TreatmentType> treatmentType = SearchResult<TreatmentType>();
  SearchResult<Category> category = SearchResult<Category>();

  int? selectedTreatmentTypeId;
  int? selectedCategoryId;

  final _formKey = GlobalKey<FormState>();
  final _validation = ValidationRules();

  File? selectedPhoto;
  String? _base64Image;
  String? _imageValidationError;

  @override
  void initState() {
    if (widget.edit == true && widget.data != null) {
      duration = TextEditingController(text: widget.data!.duration.toString());
      description = TextEditingController(text: widget.data!.description);
      price = TextEditingController(text: widget.data!.price.toString());
      name = TextEditingController(text: widget.data!.name);
      _base64Image = widget.data!.picture;
      selectedCategoryId = widget.data!.categoryId;
      selectedTreatmentTypeId = widget.data!.treatmentTypeId;
    }

    fetchData();

    super.initState();
  }

  @override
  void dispose() {
    duration.dispose();
    description.dispose();
    price.dispose();
    super.dispose();
  }

  Future<void> fetchData() async {
    treatmentType = await treatmentProvider.get();
    category = await categoryProvider.get();
    setState(() {});
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

  void _saveChanges() async {
    final provider = Provider.of<TreatmentProvider>(context, listen: false);
    if (validateForm()) {
      {
        if (widget.edit == true && widget.data != null) {
          await provider.updateTreatment(
            widget.data!.id,
            selectedTreatmentTypeId!,
            selectedCategoryId!,
            description.text,
            int.parse(duration.text),
            double.parse(price.text),
            _base64Image ?? widget.data!.picture,
            name.text,
          );
        } else {
          await provider.addTreatment(
            selectedTreatmentTypeId!,
            selectedCategoryId!,
            description.text,
            int.parse(duration.text),
            double.parse(price.text),
            _base64Image!,
            name.text,
          );
        }
        widget.refreshCallback();
        // ignore: use_build_context_synchronously
        Navigator.of(context).pop();
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: AlertDialog(
        backgroundColor: Colors.white,
        title: widget.edit
            ? const Text("Ažuriraj tretman")
            : const Text("Dodaj tretman"),
        content: Form(
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
                controller: name,
                decoration: const InputDecoration(labelText: "Naziv"),
                validator: (value) => _validation.validateTextInput(
                  value,
                  'Molim Vas unesti naziv.',
                ),
              ),
              DropdownButtonFormField<int>(
                value: selectedTreatmentTypeId,
                onChanged: (newValue) {
                  setState(() {
                    selectedTreatmentTypeId = newValue;
                  });
                },
                items: treatmentType.result.map((treatment) {
                  return DropdownMenuItem<int>(
                    value: treatment.id,
                    child: Text(treatment.name),
                  );
                }).toList(),
                decoration: const InputDecoration(labelText: 'Vrsta usluge'),
                validator: _validation.validateDropdown,
              ),
              DropdownButtonFormField<int>(
                value: selectedCategoryId,
                onChanged: (newValue) {
                  setState(() {
                    selectedCategoryId = newValue;
                  });
                },
                items: category.result.map((cat) {
                  return DropdownMenuItem<int>(
                    value: cat.id,
                    child: Text(cat.name),
                  );
                }).toList(),
                decoration: const InputDecoration(labelText: 'Kategorija'),
                validator: _validation.validateDropdown,
              ),
              TextFormField(
                controller: description,
                maxLines: 5,
                decoration: const InputDecoration(labelText: "Opis"),
                validator: (value) => _validation.validateTextInput(
                  value,
                  'Molim Vas unesti opis.',
                ),
              ),
              TextFormField(
                controller: duration,
                decoration: const InputDecoration(labelText: "Trajanje"),
                keyboardType: TextInputType.number,
                validator: (value) => _validation.validateNumberInput(
                  value,
                  'Molim vas unesite trajanje.',
                ),
              ),
              TextFormField(
                controller: price,
                decoration: const InputDecoration(labelText: "Cijena"),
                keyboardType: TextInputType.number,
                validator: _validation.validatePrice,
              ),
            ],
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
      ),
    );
  }
}
