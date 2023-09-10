import 'dart:convert';

import '../models/record.dart';
import 'base_provider.dart';
import 'package:http/http.dart' as http;

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
    print("Print datuma: ${DateTime.now()}");

    var jsonRequest = jsonEncode(<String, dynamic>{
      //"entryDate": data.entryDate,
      "leaveEntryDate": DateTime.now().toString(),
      "userId": data.userId
    });
    print("Print datuma: ${DateTime.now()}");
    print("Ispis json-a: $jsonRequest i ispis od id ${data.id}");

    var response = await http.put(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }
}
