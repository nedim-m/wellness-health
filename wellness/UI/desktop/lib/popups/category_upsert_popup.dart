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

  final _formKey = GlobalKey<FormState>();
  final _validation = ValidationRules();

  @override
  void initState() {
    if (widget.edit == true && widget.data != null) {
      name = TextEditingController(text: widget.data!.name);
      description = TextEditingController(text: widget.data!.description);
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
          ),
        );
      } else {
        await provider.insert(
          Category(0, name.text, description.text),
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
          ? const Text("Ažuriraj kategoriju")
          : const Text("Dodaj kategoriju"),
      content: Form(
        key: _formKey,
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            TextFormField(
              controller: name,
              decoration: const InputDecoration(labelText: "Naziv"),
              validator: (value) => _validation.validateTextInput(
                  value, 'Molim Vas unesite naziv.'),
            ),
            TextFormField(
              maxLines: 5,
              controller: description,
              decoration: const InputDecoration(labelText: "Opis"),
              validator: (value) => _validation.validateTextInput(
                  value, 'Molim Vas unesite opis.'),
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
    );
  }
}
