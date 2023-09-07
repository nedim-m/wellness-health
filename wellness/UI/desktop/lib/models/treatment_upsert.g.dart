// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'treatment_upsert.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TreatmentUpsert _$TreatmentUpsertFromJson(Map<String, dynamic> json) =>
    TreatmentUpsert(
      json['treatmentTypeId'] as int,
      json['categoryId'] as int,
      json['description'] as String,
      (json['price'] as num).toDouble(),
      json['duration'] as int,
      json['picture'] as String?,
    );

Map<String, dynamic> _$TreatmentUpsertToJson(TreatmentUpsert instance) =>
    <String, dynamic>{
      'treatmentTypeId': instance.treatmentTypeId,
      'categoryId': instance.categoryId,
      'description': instance.description,
      'price': instance.price,
      'duration': instance.duration,
      'picture': instance.picture,
    };
