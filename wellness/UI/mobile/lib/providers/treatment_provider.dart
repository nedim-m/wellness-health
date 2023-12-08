import 'package:mobile/models/treatment.dart';
import 'package:mobile/providers/base_provider.dart';

class TreatmentProvider extends BaseProvider<Treatment> {
  TreatmentProvider() : super("Treatment");

  @override
  Treatment fromJson(data) {
    return Treatment.fromJson(data);
  }
}
