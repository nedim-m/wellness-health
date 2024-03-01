import 'dart:typed_data';

import 'package:flutter/material.dart';
import 'dart:convert';

import '../models/treatment.dart';

class TreatmentDetailWidget extends StatelessWidget {
  const TreatmentDetailWidget({Key? key, required this.data}) : super(key: key);
  final Treatment data;

  @override
  Widget build(BuildContext context) {
    final List<int> imageBytes = base64.decode(data.picture);
    final ImageProvider decodedImage =
        MemoryImage(Uint8List.fromList(imageBytes));

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
                  controller: TextEditingController(text: data.name),
                  decoration: const InputDecoration(labelText: "Naziv"),
                  readOnly: true,
                ),
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
                  maxLines: 5,
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
          Container(
            height: 200,
            width: 200,
            decoration: BoxDecoration(
              image: DecorationImage(
                image: decodedImage,
                fit: BoxFit.cover,
              ),
            ),
          ),
        ],
      ),
      actions: [
        ElevatedButton(
          onPressed: () {
            Navigator.pop(context);
          },
          child: const Text("Zatvori"),
        ),
      ],
    );
  }
}
