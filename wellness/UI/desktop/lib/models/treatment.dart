import 'package:json_annotation/json_annotation.dart';

part 'treatment.g.dart';

@JsonSerializable()
class Treatment {
  final int id;
  final String treatmentType;
  final String category;
  final String description;
  final double price;
  final String? picture;

  factory Treatment.fromJson(Map<String, dynamic> json) =>
      _$TreatmentFromJson(json);

  Treatment(this.id, this.treatmentType, this.category, this.description,
      this.price, this.picture);

  Map<String, dynamic> toJson() => _$TreatmentToJson(this);
}
