import 'dart:convert';

import 'package:desktop/models/membership.dart';
import 'package:desktop/providers/base_provider.dart';
import 'package:http/http.dart' as http;

class MembershipProvider extends BaseProvider<Membership> {
  MembershipProvider() : super("Membership");

  @override
  Membership fromJson(data) {
    return Membership.fromJson(data);
  }

  Future<dynamic> addMembership(int userId, int memberShipTypeId) async {
    var url = "$baseUrl$endpoint";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "userId": userId,
      "memberShipTypeId": memberShipTypeId,
    });

    var response = await http.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<dynamic> updateMembership(int id, int memberShipTypeId) async {
    var url = "$baseUrl$endpoint/$id";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "memberShipTypeId": memberShipTypeId,
    });

    var response = await http.put(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }
}
