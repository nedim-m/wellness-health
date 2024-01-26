import 'package:json_annotation/json_annotation.dart';

part 'treatment_type.g.dart';

@JsonSerializable()
class TreatmentType {
  final int id;
  final String name;
  final String description;

  factory TreatmentType.fromJson(Map<String, dynamic> json) =>
      _$TreatmentTypeFromJson(json);

  TreatmentType(this.id, this.name, this.description);

  Map<String, dynamic> toJson() => _$TreatmentTypeToJson(this);
}
