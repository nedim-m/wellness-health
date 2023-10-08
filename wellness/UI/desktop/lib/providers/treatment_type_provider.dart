import 'dart:convert';

import '../models/treatment_type.dart';
import 'base_provider.dart';
import 'package:http/http.dart' as http;

class TreatmentTypeProvider extends BaseProvider<TreatmentType> {
  TreatmentTypeProvider() : super("TreatmentType");

  @override
  TreatmentType fromJson(data) {
    return TreatmentType.fromJson(data);
  }

  Future<void> delete(int id) async {
    var url = "$baseUrl$endpoint/$id";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var response = await http.delete(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }
}
