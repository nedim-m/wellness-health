// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'treatment.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Treatment _$TreatmentFromJson(Map<String, dynamic> json) => Treatment(
      json['id'] as int,
      json['treatmentType'] as String,
      json['category'] as String,
      json['description'] as String,
      (json['price'] as num).toDouble(),
      json['picture'] as String,
      json['duration'] as int,
      json['name'] as String,
      json['treatmentTypeId'] as int,
      json['categoryId'] as int,
    );

Map<String, dynamic> _$TreatmentToJson(Treatment instance) => <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'treatmentType': instance.treatmentType,
      'category': instance.category,
      'description': instance.description,
      'price': instance.price,
      'duration': instance.duration,
      'picture': instance.picture,
      'treatmentTypeId': instance.treatmentTypeId,
      'categoryId': instance.categoryId,
    };
