import 'package:json_annotation/json_annotation.dart';

part 'category.g.dart';

@JsonSerializable()
class Category {
  final int id;
  final String name;
  final String description;
  final bool status;

  Category(this.id, this.name, this.description, this.status);

  factory Category.fromJson(Map<String, dynamic> json) => _$CategoryFromJson(json);

  
  Map<String, dynamic> toJson() => _$CategoryToJson(this);


}



