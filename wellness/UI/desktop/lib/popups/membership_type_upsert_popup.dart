import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/membership_type.dart';
import '../models/treatment_type.dart';
import '../providers/membership_type.provider.dart';

import '../utils/validation_rules.dart';

class MembershipTypeEditPopUpWidget extends StatefulWidget {
  const MembershipTypeEditPopUpWidget({
    super.key,
    this.data,
    required this.edit,
  });
  final MembershipType? data;
  final bool edit;

  @override
  State<MembershipTypeEditPopUpWidget> createState() =>
      _MembershipTypeEditPopUpWidgetState();
}

class _MembershipTypeEditPopUpWidgetState
    extends State<MembershipTypeEditPopUpWidget> {
  TextEditingController name = TextEditingController();
  TextEditingController description = TextEditingController();
  TextEditingController price = TextEditingController();

  final _formKey = GlobalKey<FormState>();
  final _validation = ValidationRules();

  @override
  void initState() {
    if (widget.edit == true && widget.data != null) {
      name = TextEditingController(text: widget.data!.name);
      description = TextEditingController(text: widget.data!.description);
      price = TextEditingController(text: widget.data!.price.toString());
    }
    super.initState();
  }

  @override
  void dispose() {
    name.dispose();
    description.dispose();
    price.dispose();
    super.dispose();
  }

  void _saveChanges() async {
    final provider =
        Provider.of<MembershipTypeProvider>(context, listen: false);
    if (_formKey.currentState!.validate()) {
      if (widget.edit == true && widget.data != null) {
        provider.update(
          widget.data!.id,
          TreatmentType(widget.data!.id, name.text, description.text,
              double.parse(price.text)),
        );
      } else {
        provider.insert(
          TreatmentType(
              0, name.text, description.text, double.parse(price.text)),
        );
      }

      Navigator.of(context).pop();
    }
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: widget.edit ? const Text("Edit Item") : const Text("Add Item"),
      content: Form(
        key: _formKey,
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            TextFormField(
              controller: name,
              decoration: const InputDecoration(labelText: "Naziv"),
              validator: (value) =>
                  _validation.validateTextInput(value, 'Please enter Name.'),
            ),
            TextFormField(
              controller: description,
              decoration: const InputDecoration(labelText: "Opis"),
              validator: (value) => _validation.validateTextInput(
                  value, 'Please enter Description.'),
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
