import 'package:desktop/models/treatment_type.dart';
import 'package:desktop/providers/category_provider.dart';
import 'package:flutter/material.dart';

import '../models/category.dart';
import '../models/search_result.dart';
import '../models/treatment.dart';

import '../providers/treatment_type_provider.dart';

class TreatmenUpsertPopUpWidget extends StatefulWidget {
  const TreatmenUpsertPopUpWidget({
    super.key,
    this.data,
    required this.edit,
  });
  final Treatment? data;
  final bool edit;

  @override
  State<TreatmenUpsertPopUpWidget> createState() =>
      _TreatmenUpsertPopUpWidgetState();
}

class _TreatmenUpsertPopUpWidgetState extends State<TreatmenUpsertPopUpWidget> {
  TextEditingController description = TextEditingController();
  TextEditingController price = TextEditingController();
  TextEditingController duration = TextEditingController();
  final TreatmentTypeProvider treatmentProvider = TreatmentTypeProvider();
  final CategoryProvider categoryProvider = CategoryProvider();

  SearchResult<TreatmentType> treatmentType = SearchResult<TreatmentType>();
  SearchResult<Category> category = SearchResult<Category>();

  int? selectedTreatmentTypeId;
  int? selectedCategoryId;

  @override
  void initState() {
    if (widget.edit == true && widget.data != null) {
      duration = TextEditingController(text: widget.data!.duration.toString());
      description = TextEditingController(text: widget.data!.description);
      price = TextEditingController(text: widget.data!.price.toString());
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

  void _saveChanges() async {
    /*final provider =
        Provider.of<TreatmentUpsertProvider>(context, listen: false);
    if (widget.edit == true && widget.data != null) {
      provider.update(
          widget.data!.id,
          TreatmentUpsert(
              selectedTreatmentTypeId!,
              selectedCategoryId!,
              description.text,
              double.parse(price.text),
              int.parse(duration.text),
              null));
    } else {
      provider.insert(
        (
          0,
          selectedTreatmentTypeId!,
          selectedCategoryId!,
          description.text,
          int.parse(duration.text),
          double.parse(price.text),
        ),
      )
    }*/

    Navigator.of(context).pop();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: widget.edit ? const Text("Edit Item") : const Text("Add Item"),
      content: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
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
          ),
          TextField(
            controller: description,
            decoration: const InputDecoration(labelText: "Opis"),
          ),
          TextField(
            controller: duration,
            decoration: const InputDecoration(labelText: "Trajanje"),
            keyboardType: TextInputType.number,
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
