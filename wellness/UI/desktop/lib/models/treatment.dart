import 'package:json_annotation/json_annotation.dart';

part 'treatment.g.dart';

@JsonSerializable()
class Treatment {
  final int id;
  final String name;
  final String treatmentType;
  final String category;
  final String description;
  final double price;
  final int duration;
  final String picture;
  final int treatmentTypeId;
  final int categoryId;

  factory Treatment.fromJson(Map<String, dynamic> json) =>
      _$TreatmentFromJson(json);

  Treatment(this.id, this.treatmentType, this.category, this.description,
      this.price, this.picture, this.duration, this.name, this.treatmentTypeId, this.categoryId);

  Map<String, dynamic> toJson() => _$TreatmentToJson(this);
}
