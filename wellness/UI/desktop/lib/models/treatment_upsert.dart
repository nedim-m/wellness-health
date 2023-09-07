import 'package:json_annotation/json_annotation.dart';

part 'treatment_upsert.g.dart';

@JsonSerializable()
class TreatmentUpsert {
  final int treatmentTypeId;
  final int categoryId;
  final String description;
  final double price;
  final int duration;
  final String? picture;

  factory TreatmentUpsert.fromJson(Map<String, dynamic> json) =>
      _$TreatmentUpsertFromJson(json);

  TreatmentUpsert(this.treatmentTypeId, this.categoryId, this.description, this.price, this.duration, this.picture);

  Map<String, dynamic> toJson() => _$TreatmentUpsertToJson(this);
}
