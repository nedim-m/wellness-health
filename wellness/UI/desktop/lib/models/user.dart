import 'package:json_annotation/json_annotation.dart';

part 'user.g.dart';

@JsonSerializable()
class User {
  final int id;
  final String firstName;
  final String lastName;
  final String email;
  final String userName;
  final String phone;
  final bool status;
  final String picture;
  final String? role;
  final String? shiftTime;
  final int roleId;
  final int shiftId;
  final String? membershipType;

  User(this.id, this.firstName, this.lastName, this.email, this.userName,
      this.phone, this.status, this.picture, this.role, this.shiftTime, this.roleId, this.shiftId, this.membershipType);

  factory User.fromJson(Map<String, dynamic> json) => _$UserFromJson(json);

  Map<String, dynamic> toJson() => _$UserToJson(this);
}
