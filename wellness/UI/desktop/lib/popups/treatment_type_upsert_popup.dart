import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/treatment_type.dart';
import '../providers/treatment_type_provider.dart';

class TreatmentEditPopUpWidget extends StatefulWidget {
  const TreatmentEditPopUpWidget({
    super.key,
    this.data,
    required this.edit,
  });
  final TreatmentType? data;
  final bool edit;

  @override
  State<TreatmentEditPopUpWidget> createState() =>
      _TreatmentEditPopUpWidgetState();
}

class _TreatmentEditPopUpWidgetState extends State<TreatmentEditPopUpWidget> {
  TextEditingController name = TextEditingController();
  TextEditingController description = TextEditingController();
  TextEditingController price = TextEditingController();

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
    final provider = Provider.of<TreatmentTypeProvider>(context, listen: false);
    if (widget.edit == true && widget.data != null) {
      provider.update(
        widget.data!.id,
        TreatmentType(widget.data!.id, name.text, description.text,
            double.parse(price.text)),
      );
    } else {
      provider.insert(
        TreatmentType(0, name.text, description.text, double.parse(price.text)),
      );
    }

    Navigator.of(context).pop();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: widget.edit ? const Text("Edit Item") : const Text("Add Item"),
      content: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          TextField(
            controller: name,
            decoration: const InputDecoration(labelText: "Naziv"),
          ),
          TextField(
            controller: description,
            decoration: const InputDecoration(labelText: "Opis"),
          ),
          TextField(
            controller: price,
            decoration: const InputDecoration(labelText: "Cijena"),
            keyboardType: TextInputType.number,
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