import 'package:desktop/models/category.dart';
import 'package:desktop/providers/category_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../utils/validation_rules.dart';

class CategoryEditPopUpWidget extends StatefulWidget {
  const CategoryEditPopUpWidget({
    super.key,
    this.data,
    required this.edit,
    required this.refreshCallback,
  });
  final Category? data;
  final bool edit;
  final Function() refreshCallback;

  @override
  State<CategoryEditPopUpWidget> createState() =>
      _CategoryEditPopUpWidgetState();
}

class _CategoryEditPopUpWidgetState extends State<CategoryEditPopUpWidget> {
  TextEditingController name = TextEditingController();
  TextEditingController description = TextEditingController();
  bool selectedStatus = false;
  final _formKey = GlobalKey<FormState>();
  final _validation = ValidationRules();

  @override
  void initState() {
    if (widget.edit == true && widget.data != null) {
      name = TextEditingController(text: widget.data!.name);
      description = TextEditingController(text: widget.data!.description);
      selectedStatus = widget.data!.status;
    }
    super.initState();
  }

  @override
  void dispose() {
    name.dispose();
    description.dispose();
    super.dispose();
  }

  void _saveChanges() async {
    final provider = Provider.of<CategoryProvider>(context, listen: false);

    if (_formKey.currentState!.validate()) {
      if (widget.edit == true && widget.data != null) {
        await provider.update(
          widget.data!.id,
          Category(
            widget.data!.id,
            name.text,
            description.text,
            selectedStatus,
          ),
        );
      } else {
        await provider.insert(
          Category(0, name.text, description.text, selectedStatus),
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
