import 'dart:convert';

import '../models/record.dart';
import 'base_provider.dart';
import 'package:http/http.dart' as http;
import 'package:intl/intl.dart';

class RecordProvider extends BaseProvider<Records> {
  RecordProvider() : super("Record");

  @override
  Records fromJson(data) {
    return Records.fromJson(data);
  }

  Future<dynamic> leaveEntry(
    dynamic data,
  ) async {
    var url = "$baseUrl$endpoint/${data.id}";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    DateTime now = DateTime.now();
    String formattedDateTime = DateFormat('dd.MM.yy - HH:mm').format(now);

    //print("Formatiran datum : $formattedDateTime");
    var jsonRequest = jsonEncode(<String, dynamic>{
      "entryDate": data.entryDate,
      "leaveEntryDate": formattedDateTime,
      "userId": data.userId
    });

    var response = await http.put(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<dynamic> addEntry(
    dynamic data,
  ) async {
    var url = "$baseUrl$endpoint";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    DateTime now = DateTime.now();
    String formattedDateTime = DateFormat('dd.MM.yy - HH:mm').format(now);

    print("Formatiran datum : $formattedDateTime");
    var jsonRequest = jsonEncode(<String, dynamic>{
      "entryDate": formattedDateTime,
      "userId": data.id,
      "leaveEntryDate": null
    });

    var response = await http.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }
}
