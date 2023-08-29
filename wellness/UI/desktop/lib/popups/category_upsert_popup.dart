import 'package:desktop/models/category.dart';
import 'package:desktop/providers/category_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class CategoryEditPopUpWidget extends StatefulWidget {
  const CategoryEditPopUpWidget({
    super.key,
    this.data,
    required this.edit,
  });
  final Category? data;
  final bool edit;

  @override
  State<CategoryEditPopUpWidget> createState() =>
      _CategoryEditPopUpWidgetState();
}

class _CategoryEditPopUpWidgetState extends State<CategoryEditPopUpWidget> {
  TextEditingController name = TextEditingController();
  TextEditingController description = TextEditingController();
  bool selectedStatus = false; // Holds the selected status value

  @override
  void initState() {
    if (widget.edit == true && widget.data != null) {
      name = TextEditingController(text: widget.data!.name);
      description = TextEditingController(text: widget.data!.description);
      selectedStatus = widget.data!.status; // Set the initial status value
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
    if (widget.edit == true && widget.data != null) {
      provider.update(
        widget.data!.id,
        Category(
          widget.data!.id,
          name.text,
          description.text,
          selectedStatus,
        ),
      );
    } else {
      provider.insert(
        Category(0, name.text, description.text, selectedStatus),
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
