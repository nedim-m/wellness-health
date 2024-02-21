import 'package:json_annotation/json_annotation.dart';

part 'role.g.dart';

@JsonSerializable()
class Role {
  final int id;
  final String name;
  final String description;

  factory Role.fromJson(Map<String, dynamic> json) => _$RoleFromJson(json);

  Role(this.id, this.name, this.description);

  Map<String, dynamic> toJson() => _$RoleToJson(this);
}
