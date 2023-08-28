import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/treatment_type.dart';
import '../providers/treatment_type_provider.dart';

class TreatmentEditPopUpWidget extends StatefulWidget {
  const TreatmentEditPopUpWidget({
    super.key,
    required this.data,
  });
  final TreatmentType data;

  @override
  State<TreatmentEditPopUpWidget> createState() =>
      _TreatmentEditPopUpWidgetState();
}

class _TreatmentEditPopUpWidgetState extends State<TreatmentEditPopUpWidget> {
  late TextEditingController name;
  late TextEditingController description;
  late TextEditingController price;

  @override
  void initState() {
    name = TextEditingController(text: widget.data.name);
    description = TextEditingController(text: widget.data.description);
    price = TextEditingController(text: widget.data.price.toString());

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
    provider.update(
      widget.data.id,
      TreatmentType(widget.data.id, name.text, description.text,
          double.parse(price.text)),
    );

    Navigator.of(context).pop();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text("Edit Item"),
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
