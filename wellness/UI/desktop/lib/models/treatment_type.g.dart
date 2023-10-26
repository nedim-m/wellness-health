// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'treatment_type.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TreatmentType _$TreatmentTypeFromJson(Map<String, dynamic> json) =>
    TreatmentType(
      json['id'] as int,
      json['name'] as String,
      json['description'] as String,
      (json['price'] as num).toDouble(),
    );

Map<String, dynamic> _$TreatmentTypeToJson(TreatmentType instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'description': instance.description,
      'price': instance.price,
    };
