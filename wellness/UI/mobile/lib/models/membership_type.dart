import 'package:json_annotation/json_annotation.dart';

part 'membership_type.g.dart';

@JsonSerializable()
class MembershipType {
  final int id;
  final String name;
  final String description;
  final double price;
  final int duration;

  MembershipType(this.id, this.name, this.description, this.price, this.duration);
  factory MembershipType.fromJson(Map<String, dynamic> json) =>
      _$MembershipTypeFromJson(json);

  Map<String, dynamic> toJson() => _$MembershipTypeToJson(this);
}
