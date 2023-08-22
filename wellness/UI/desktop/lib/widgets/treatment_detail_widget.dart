import 'package:flutter/material.dart';

import '../models/treatment.dart';

class TreatmentDetailWidget extends StatelessWidget {
  const TreatmentDetailWidget({super.key, required this.data});
  final Treatment data;

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text("Detalji tretmana"),
      content: Row(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Expanded(
            child: Column(
              mainAxisSize: MainAxisSize.min,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                TextFormField(
                  controller: TextEditingController(text: data.treatmentType),
                  decoration: const InputDecoration(labelText: "Vrsta usluge"),
                  readOnly: true,
                ),
                TextFormField(
                  controller: TextEditingController(text: data.category),
                  decoration: const InputDecoration(labelText: "Kategorija"),
                  readOnly: true,
                ),
                TextFormField(
                  controller: TextEditingController(text: data.description),
                  decoration: const InputDecoration(labelText: "Opis"),
                  readOnly: true,
                ),
                TextFormField(
                  controller:
                      TextEditingController(text: data.price.toString()),
                  decoration: const InputDecoration(labelText: "Cijena"),
                  readOnly: true,
                ),
                TextFormField(
                  controller:
                      TextEditingController(text: "${data.duration} minuta"),
                  decoration: const InputDecoration(labelText: "Trajanje"),
                  readOnly: true,
                ),
              ],
            ),
          ),
          if (data.picture != null)
            Image.network(
              data.picture!,
              height: 100,
              width: 100,
            ),
        ],
      ),
      actions: [
        ElevatedButton(
          onPressed: () {
            Navigator.pop(context);
          },
          child: const Text("Close"),
        ),
      ],
    );
  }
}
