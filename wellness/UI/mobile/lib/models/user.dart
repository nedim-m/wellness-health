import 'package:json_annotation/json_annotation.dart';

part 'user.g.dart';

@JsonSerializable()
class User {
  final String firstName;
  final String lastName;
  final String email;
  final String userName;
  final String phone;

  User(this.firstName, this.lastName, this.email, this.userName, this.phone);

  factory User.fromJson(Map<String, dynamic> json) => _$UserFromJson(json);

  Map<String, dynamic> toJson() => _$UserToJson(this);
}
