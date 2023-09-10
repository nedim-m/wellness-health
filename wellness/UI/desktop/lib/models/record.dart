import 'package:json_annotation/json_annotation.dart';

part 'record.g.dart';

@JsonSerializable()
class Records {
  final int id;
  final String? entryDate;
  final String? leaveEntryDate;
  final int userId;
  final String firstName;
  final String lastName;
  final String phone;
  final String userName;

  factory Records.fromJson(Map<String, dynamic> json) =>
      _$RecordsFromJson(json);

  Records(this.id, this.entryDate, this.leaveEntryDate, this.userId,
      this.firstName, this.lastName, this.phone, this.userName);

  Map<String, dynamic> toJson() => _$RecordsToJson(this);
}
