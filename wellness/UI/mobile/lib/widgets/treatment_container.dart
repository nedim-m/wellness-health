import 'dart:convert';
import 'dart:typed_data';

import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/models/treatment.dart';

import 'package:mobile/utils/app_styles.dart';

class TreatmentRecomendationView extends StatelessWidget {
  final Treatment treatment;
  const TreatmentRecomendationView({
    Key? key,
    required this.treatment,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final List<int> imageBytes = base64.decode(treatment.picture ?? '');
    final ImageProvider decodedImage =
        MemoryImage(Uint8List.fromList(imageBytes));

    return Container(
      width: 250,
      height: 350,
      padding: const EdgeInsets.symmetric(horizontal: 15, vertical: 17),
      margin: const EdgeInsets.only(right: 17, top: 5),
      decoration: BoxDecoration(
        color: Styles.primaryColor,
        borderRadius: BorderRadius.circular(24),
        boxShadow: [
          BoxShadow(
            color: Colors.grey.shade200,
            blurRadius: 20,
            spreadRadius: 5,
          ),
        ],
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          if (treatment.picture != null)
            Container(
              height: 180,
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(12),
                color: Styles.primaryColor,
                image: DecorationImage(
                  fit: BoxFit.cover,
                  image: decodedImage,
                ),
              ),
            ),
          const Gap(10),
          Text(
            treatment.name,
            style: Styles.headLineStyle2.copyWith(color: Styles.kakiColor),
          ),
          const Gap(5),
          Text(
            treatment.category,
            style: Styles.headLineStyle3.copyWith(color: Colors.white),
          ),
          const Gap(8),
          Text(
            'Duration: ${treatment.duration} min',
            style: Styles.headLineStyle3.copyWith(color: Colors.white),
          ),
          const Gap(8),
          Row(
            children: [
              Text(
                'Average Rating: ${treatment.averageRating!.toStringAsFixed(1)}',
                style: Styles.headLineStyle3.copyWith(color: Colors.white),
              ),
              const Icon(
                Icons.star,
                color: Colors.yellow,
              ),
            ],
          ),
        ],
      ),
    );
  }
}
